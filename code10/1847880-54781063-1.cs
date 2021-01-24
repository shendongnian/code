    public static class DataSeeder
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            var dbManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbManager.Database.Migrate();
            Brand Addiction;
            Addiction = new Brand()
            {
                BrandName = "Addiction"
            };
            dbManager.Brands.Add(Addiction);
            dbManager.SaveChanges();
            return;
        }
    }
