    class CarContext : DbContext
    {
        public DbSet<CarMake> CarMakes {get; set;}
        public DbSet<CarModel> CarModels {get; set;}
    }
