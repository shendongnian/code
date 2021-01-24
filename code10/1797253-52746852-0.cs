    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    
    namespace EfCoreTest
    {
        public partial class FooContext : DbContext
        {
            public FooContext()
            {
            }
    
            public FooContext(DbContextOptions<FooContext> options)
                : base(options)
            {
            }
    
            public virtual DbSet<Users> Users { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("server=.;database=Foo;Integrated Security=true");
                }
            }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Users>(entity =>
                {
                    entity.Property(e => e.Id).ValueGeneratedNever();
    
                    entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(150);
    
                    entity.HasOne(d => d.CreatedBy)
                        .WithMany(p => p.InverseCreatedBy)
                        .HasForeignKey(d => d.CreatedById)
                        .OnDelete(DeleteBehavior.ClientSetNull);
    
                    entity.HasOne(d => d.UpdatedBy)
                        .WithMany(p => p.InverseUpdatedBy)
                        .HasForeignKey(d => d.UpdatedById);
                });
            }
        }
    }
