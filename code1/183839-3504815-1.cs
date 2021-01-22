        protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
        {
            var properties = new[]
            {
                modelBuilder.Entity<Product>().Property(product => product.Price),
                modelBuilder.Entity<Order>().Property(order => order.OrderTotal),
                modelBuilder.Entity<OrderDetail>().Property(detail => detail.Total),
                modelBuilder.Entity<Option>().Property(option => option.Price)
            };
            properties.ToList().ForEach(property =>
            {
                property.Precision = 10;
                property.Scale = 2;
            });
            base.OnModelCreating(modelBuilder);
        }
