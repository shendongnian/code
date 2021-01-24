    RepositoryCategory FetchCategory(int categoryId)
    {
         using (var dbContext = new MyDbContext())
         {
             return dbContext.Categories.Where(category => category.Id == categoryId)
                .Select(category => new RepositoryCategory
                {
                     ... // see above
                })
                .FirstOrDefault();
         }
    }
