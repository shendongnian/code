       public DbSet<Pizza> Pizzas { get; set; }
       public DbSet<Sauce> Sauces { get; set; }
       public DbSet<Idgredient> Idgredients { get; set; }
       public DbSet<Order> Orders { get; set; }
       public DbSet<OrderSauceItem> OrderSauce { get; set; }
       public DbSet<OrderPizzaItem> OrderPizza { get; set; }
       public DbSet<PizzaIdgredientItem> PizzaIdgredient { get; set; }
