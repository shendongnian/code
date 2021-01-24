    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    
    namespace ConsoleApp2
    {
        class ProductType
        {
    
        }
    
        class OtherType
        {
            public ProductType Product { get; set; }
        }
    
        class MyDbContext : DbContext
        {
            public DbSet<OtherType> Others { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var dbContext = new MyDbContext();
    
                Expression<Func<OtherType, ProductType>> expression = e => e.Product; // your expression is here
    
                IQueryable<OtherType> query = dbContext.Others;
                query = query.Include(expression);
            }
        }
    }
