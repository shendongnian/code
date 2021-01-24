    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    
    namespace ConsoleApp2
    {
        class Product
        {
    
        }
    
        class Shop
        {
    
        }
    
        class SomeEntity
        {
            public Product Product { get; set; }
            public Shop Shop { get; set; }
        }
    
        class MyDbContext : DbContext
        {
            public DbSet<SomeEntity> Entities { get; set; }
        }
    
        class Program
        {
            private static Expression<Func<SomeEntity, Object>> GetExpression()
            {
                // a stupid random strategy
                if (DateTime.Now.Ticks % 2 == 0)
                {
                    Expression<Func<SomeEntity, Object>> expression = e => e.Shop;
                    return expression;
                }
                else
                {
                    Expression<Func<SomeEntity, Object>> expression = e => e.Product;
                    return expression;
                }
            }
    
            static void Main(string[] args)
            {
                var dbContext = new MyDbContext();
    
                IQueryable<SomeEntity> query = dbContext.Entities;
    
                var expression = GetExpression();
    
                query = query.Include(expression);
            }
        }
    }
