    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    
    namespace EFTest
    {
       public class EFTestContext : DbContext
       {
          public virtual DbSet<User> Users { get; set; }
          public virtual DbSet<Permission> Permissions { get; set; }
    
          protected override void OnModelCreating( DbModelBuilder modelBuilder )
          {
             base.OnModelCreating( modelBuilder );
          }
       }
    
       public class User
       {
          [Key]
          public int Id { get; set; }
          public string Name { get; set; }
    
          public virtual ICollection<Permission> Permissions { get; set; }
       }
    
       public class Permission
       {
          [Key, Column( Order = 1 )]
          public string Name { get; set; }
          [Key, Column( Order = 2 ), ForeignKey( nameof( User ) )]
          public int UserId { get; set; }
    
          public virtual User User { get; set; }
       }
    }
