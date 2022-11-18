﻿using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfacees;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _CategoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _CategoryContext = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _CategoryContext.Add(category);
            await _CategoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _CategoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _CategoryContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _CategoryContext.Remove(category);
            await _CategoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _CategoryContext.Update(category);
            await _CategoryContext.SaveChangesAsync();
            return category;
        }
    }
}
