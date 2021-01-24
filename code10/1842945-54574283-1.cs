    public async Task<List<object>> GetFilteredEntityList(string entityClassName, string name, string lastName)
    {
          var type = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == entityClassName);
    
          if (type != null)
          {
             DbSet dbSet = _dbContext.Set(type);
    
             IQueryable entityListQueryable = dbSet;
             if (!string.IsNullOrEmpty(name))
             {
                  entityListQueryable = entityListQueryable.Where("Name == @0", name);
             }
             if (!string.IsNullOrEmpty(lastName))
             {
                  entityListQueryable = entityListQueryable.Where("LastName == @0", lastName);
             }
             return await entityListQueryable.ToListAsync();
         }
         else
         {
            throw new Exception("Table name does not exist with the provided entity class name");
         }
    }
