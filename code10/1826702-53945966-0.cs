    public static class DatabaseInitializer
    {
        public static void Initialize(YourDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Users.Any())
            {
                // Write you necessary to code here to insert the User to database and save the the information to file.
                
            }
        }
    }
