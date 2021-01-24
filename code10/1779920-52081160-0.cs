    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    
    namespace Ef6Test
    {
        public class Item
        {
            public int ItemID { get; private set; }
    
            //public virtual Category Category { get; set; }
    
            public string Description { get; set; }
    
            public string ItemLookupCode { get; private set; }
    
            public virtual Item GlobalItem { get; set; }
    
            public virtual Item DepositItem { get; set; }
    
            public bool IsDeleted { get; set; }
    
            //public virtual ItemExtension ItemExtension { get; set; }
    
    
    
            public Item() { }
        }
        class Db : DbContext
        {
    
           public DbSet<Item> Items { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Item>().HasKey(o => o.ItemID);
    
                modelBuilder.Entity<Item>().ToTable("Item", "dbo");
    
                // Relationships
                //HasRequired(t => t.Category)
                //    .WithMany(o => o.Items)
                //    .Map(m => m.MapKey("CategoryID"));
    
                modelBuilder.Entity<Item>().HasOptional(o => o.GlobalItem)
                    .WithMany()
                    .Map(m => m.MapKey("GlobalItemID"));
    
                modelBuilder.Entity<Item>().HasOptional(o => o.DepositItem)
                    .WithMany()
                    .Map(m => m.MapKey("DepositItemID"));
    
                //HasOptional(o => o.ItemExtension)
                //    .WithRequired(o => o.Item);
    
    
    
            }
    
    
    
            class Program
            {
    
    
                static void Main(string[] args)
                {
    
                    Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
    
    
                    using (var db = new Db())
                    {
                        db.Database.Log = m => Console.WriteLine(m);
                        db.Database.Initialize(true);
    
                        var items = db.Items.ToList();
                          
    
                    }
    
    
                    Console.WriteLine("Hit any key to exit");
                    Console.ReadKey();
                }
            }
        }
    }
