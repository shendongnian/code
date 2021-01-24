    public MyOtherDbContext : DbContext
    {
         public DbSet<ExtendePerson> ExtendedPersons {get; set;}
         public DbSet<Grade> Grades {get; set;}   
         public DbSet<Hobby> Hobbies {get; set;}
         public override void OnModelCreating(...)
         {
             // every extended person has zero or more Grades
             // every Grade belongs to exactly one Person
             // using foreign key PersonId
             modelBuilder.Entity<ExtendedPerson>()
                 .HasMany(extendedPerson => extendedPerson.Grades)
                 .WithRequired(grade => grade.Person)
                 .HasForeignKey(grade => grade.PersonId);
             // every extended person has zero or more hobbies
             // every hobby belongs to exactly one ExtendedPerson
             // using foreign  key ExtendedPersonId
             modelBuilder.Entity<ExtendedPerson>()
                 .HasMany(extendedPerson => extendedPerson.Hobbies)
                 .WithRequired(hobby => hobby.ExtendedPerson)
                 .HasForeignKey(hobby => hobby.ExtendedPersonId);
             // proper table name for hobbies:
             modelBuilder.Entity<Hobby>().ToTable("Hobbies");
         }
    }
