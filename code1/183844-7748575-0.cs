     public class ProductConfiguration : EntityTypeConfiguration<Product>
        {
            public ProductConfiguration()
            {
                this.Property(m => m.Price).HasPrecision(10, 2);
            }
        }
