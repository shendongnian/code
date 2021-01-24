        public async Task<int> UpdateAsync(ApplicationUser user)
        {
                _context.Entry(user).State = EntityState.Modified;
                return await _context.SaveChangesAsync();               
        }
