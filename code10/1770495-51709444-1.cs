    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    
    namespace EfCoreTest
    {
    
        public class Category
        {
            public int CategoryId { get; set; }
            public virtual ICollection<Product> Readings { get; } = new HashSet<Product>();
        }
        public class Product
        {
            public int ProductId{ get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public Category Category { get; set; }
    
            
        }
    
        public class Db : DbContext
        {
            public DbSet<Category> Categorys { get; set; }
            public DbSet<Product> Products { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("server=.;database=EfCoreTest;Integrated Security=true");
                base.OnConfiguring(optionsBuilder);
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    
        class Program
        {
        
            static void Main(string[] args)
            {
    
                using (var db = new Db())
                {
    
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
    
                    for (int i = 0; i < 100; i++)
                    {
                        var t = new Category();
    
                        for (int j = 0; j < 1000; j++)
                        {
                            var product = new Product()
                            {
                                Category = t,
                                Date = DateTime.Now,
                                Name = $"Category {j}{i}"
    
                            };
                            db.Add(product);
                        }
                        db.Add(t);
                        
                        
                    }
                    db.SaveChanges();
    
    
    
                }
                using (var db = new Db())
                {
                    var q = db.Categorys.Select(t => new
                    {
                        t.CategoryId,
                        FirstName = t.Readings.OrderByDescending(r => r.Date).Select(r => r.Name).FirstOrDefault()
                    });
    
                    var l = q.ToList();
    
                    Console.WriteLine("Hit any key to exit.");
                    Console.ReadKey();
    
                }
                
            }
        }
    }
