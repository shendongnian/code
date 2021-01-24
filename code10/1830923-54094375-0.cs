    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace EfCoreTest
    {
        public class Account
        {
            public Guid Id { get; set; }
    
            [MaxLength(2000)]
            public string UserName { get; set; }
    
        }
        public class Db : DbContext
        {
            readonly string connectionString;
    
            public DbSet<Account> Accounts { get; set; }
            public void SwitchUsernames(Guid personIdOld, Guid personIdNew)
            {
                // Get accounts
                var personOld = Accounts.Find(personIdOld);
                var personNew = Accounts.Find(personIdNew);
    
                // switch usernames
                string usernamePersonOld = personOld.UserName;
                string usernamePersonNew = personNew.UserName;
    
                using (var tran = this.Database.BeginTransaction())
                {
                    var temp = "TempName" + Guid.NewGuid().ToString();
                    personOld.UserName = temp;
                    this.SaveChanges();
    
                    personNew.UserName = usernamePersonOld;
                    this.SaveChanges();
    
                    personOld.UserName = usernamePersonNew;
                    this.SaveChanges();
    
                    tran.Commit();
                }
            }
        
            public Db(): this("server=.;database=EfCoreTest;Integrated Security=true")
            {
    
            }
            public Db(string connectionString)
            {
                this.connectionString = connectionString;
            }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(connectionString);
                base.OnConfiguring(optionsBuilder);
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //EF does not support updating key values, so you can't declare this 
                //an alternate key in the model
                //modelBuilder.Entity<Account>().HasAlternateKey(a => a.UserName);
    
                modelBuilder.Entity<Account>().HasIndex(a => a.UserName).IsUnique();
                base.OnModelCreating(modelBuilder);
            }
        }
    
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Guid aid, bid;
    
                using (var db = new Db())
                {
    
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
    
                    var a = new Account() { UserName = "A" };
                    var b = new Account() { UserName = "B" };
    
                    db.Accounts.Add(a);
                    db.Accounts.Add(b);
                    db.SaveChanges();
                    aid = a.Id;
                    bid = b.Id;
                    Console.WriteLine($"{a.Id} {a.UserName}");
                    Console.WriteLine($"{b.Id} {b.UserName}");
                }
    
                using (var db = new Db())
                {
                    db.SwitchUsernames(aid,bid);
                }
    
                using (var db = new Db())
                {
                    var a = db.Accounts.Find(aid);
                    var b = db.Accounts.Find(bid);
                    Console.WriteLine($"{a.Id} {a.UserName}");
                    Console.WriteLine($"{b.Id} {b.UserName}");
    
                }
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
             
                
            }
        }
    }
