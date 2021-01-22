    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("DB_PRODUCTS_TBL");
            // otherwise EF assumes the table is called "Products"
        }
    }
