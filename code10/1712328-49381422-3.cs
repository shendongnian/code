    public MyOtherDbContext : DbContext
    {
         public DbSet<ExtendePerson> ExtendedPersons {get; set;}
         public DbSet<Grade> Grades {get; set;}   
         public DbSet<Hobby> Hobbies {get; set;}
         public override void OnModelCreating(...)
         {
             // every extended person has zero or more Grades:
             modelBuilder.Entity<ExtendedPerson>()
                 .HasMany(extendedPerson => extendedPerson.Grades)
                 .WithRequired(grade => grade.Person)
                 .HasForeignKey(grade => grad.PersonId);
             // every extended person has zero or more hobbies:
             modelBuilder.Entity<ExtendedPerson>()
                 .HasMany(extendedPerson => extendedPerson.Hobbies)
                 .WithRequired(hobby => hobby.Person)
                 .HasForeignKey(hobby => hobby.PersonId);
             // proper table name for hobbies:
             modelBuilder.Entity<Hobby>().ToTable("Hobbies");
         }
    }
