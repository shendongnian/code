    public MyDbContext : DbContext
    {
         public DbSet<Person> Persons {get; set;}
         public DbSet<Grade> Grades {get; set;}   
         public override void OnModelCreating(...)
         {
             // a person has zero or more Grades:
             modelBuilder.Entity<Person>()
                 .HasMany(person => person.Grades)
                 .WithRequired(grade => grade.Person)
                 .HasForeignKey(grade => grad.PersonId);
         }
    }
