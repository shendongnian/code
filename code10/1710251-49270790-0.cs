    public async Task<IEnumerable<User>> GetUsersByContinent(int? continentId)
    {
         var baseQuery= _context.Users.Include(u => u.Country).ThenInclude(c => c.Continent);
    
         if (continentId.HasValue){
             baseQuery = baseQuery.Where(u => u.Country.ContinentId == continentId)
         }
    
         return await baseQuery.OrderBy(u => u.Username).ToListAsync();
    }
