    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    
    namespace MVCOurselves.Models
    {
        public class MVCOurselvesContext : IdentityDbContext
        {
            public DbSet<Student> Students { get; set; }
            public DbSet<Grade> Grades { get; set; }
    
            public MVCOurselvesContext (DbContextOptions<MVCOurselvesContext> 
    options)
                : base(options)
            {
            }
    
            protected override void OnModelCreating(ModelBuilder 
    modelBuilder)
            {
                // configures one-to-many relationship
                modelBuilder.Entity<Grades>()
                            .HasMany(g => g.Students)
                            .WithOne(s => s.Grade)
                            .HasForeignKey(s => s.GradeId);
            }
    
        }
    
    }
