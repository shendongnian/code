    services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(
            Configuration.GetConnectionString("MySqlConnection"));
    });
