    public MyContext (DbContextOptions<MyContext> options)
                : base(options)
            {
                Database.Migrate();
            }
