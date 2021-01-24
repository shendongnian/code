    public class Order
    {
        public int OrderId { get; set; } // primary key
        public List<Article> Articles { get; set; } // navigation property
    }
    
    public class Article
    {
        public int ArticleId { get; set; } // primary key
        public string Name { get; set; }
    
        public int OrderId { get; set; } // foreign key
        public Order Order { get; set; } // navigation property
    }
    public MyDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
    var foo = ctx.Orders.Include(e => e.Articles).ToList();
