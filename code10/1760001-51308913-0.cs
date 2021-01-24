    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    namespace EfCoreTest
    {
    
        public class Level
        {
            public int LevelId { get; set; }
            public int? ParentLevelId { get; set; }
            public string Name { get; set; }
    
            public virtual Level Parent { get; set; }
            public virtual HashSet<Level> Children { get; set; }
        }
    
        public class Db : DbContext
        {
            public DbSet<Level> levels { get; set; }
    
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("server=.;database=EfCoreTest;Integrated Security=true");
                base.OnConfiguring(optionsBuilder);
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Level>()
                            .HasOne(x => x.Parent)
                            .WithMany(x => x.Children)
                            .HasForeignKey(x => x.ParentLevelId);
    
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
    
                    Console.ReadKey();
    
    
    
                }
                
            }
        }
    }
