    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    //using Microsoft.Samples.EFLogging;
    using System.Data.SqlClient;
    using System.Xml.Linq;
    using System.Threading.Tasks;
    
    namespace EFCore2Test
    {
    
        public class User
        {
            [Key]
            [DatabaseGenerated( DatabaseGeneratedOption.None)]
            public int UserId { get; set; }
            public string Username { get; set; }
            public int GroupId { get; set; }
    
            public Group GroupThisUserBelongsTo { get; set; }
            public ICollection<Group> GroupsLockedByThisUser { get; set; }
    
            public ICollection<Config> Configs { get; set; }
        }
        public class Group
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int GroupId { get; set; }
            public string GroupName { get; set; }
            public int? LockedByUserId { get; set; }
    
            public User LockedByUser { get; set; }
            public ICollection<User> Users { get; set; }
        }
    
        public class Config
        {
            [Key]
            public int ConfigId { get; set; }
            public int UserId { get; set; }
            public string ConfigName { get; set; }
    
            public User User { get; set; }
        }
    
        public class Db : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Group> Groups { get; set; }
    
            public DbSet<Config> Configs { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Group>()
                    .HasOne(d => d.LockedByUser)
                    .WithMany(p => p.GroupsLockedByThisUser)
                    .HasForeignKey(d => d.LockedByUserId);            
    
                modelBuilder.Entity<User>()
                    .HasOne(d => d.GroupThisUserBelongsTo)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
    
                modelBuilder.Entity<Config>()
                    .HasOne(d => d.User)
                    .WithMany(p => p.Configs)
                    .HasForeignKey(d => d.UserId);            
    
                base.OnModelCreating(modelBuilder);
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(local);Database=EFCoreTest;Trusted_Connection=True;MultipleActiveResultSets=true");
                base.OnConfiguring(optionsBuilder);
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
                    //db.ConfigureLogging(s => Console.WriteLine(s));
    
                    var g = new Group()
                    {
                        GroupName = "G"
                    };
    
                    var u = new User()
                    {
                        UserId = 123456,
                        GroupThisUserBelongsTo = g
                    };                
    
                    db.Users.Add(u);
                    db.SaveChanges();
    
                    g.LockedByUser = u;
                    db.SaveChanges();
    
                }
    
                using (var db = new Db())
                {
                    var config = new Config
                    {
                        UserId = 123456,
                        ConfigName = "test"
                    };
    
                    db.Configs.Add(config);
                    db.SaveChanges();
                }
    
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
            }
        }
    }
