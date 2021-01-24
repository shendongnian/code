        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Build many-to-many relationships
            modelBuilder.Entity<Student>()
                          .HasMany<Course>(c => c.Courses)
                          .WithMany(s => s.Student)
                          .Map(pe =>
                          {
                              pe.MapLeftKey("Student_ID");
                              pe.MapRightKey("Course_ID");
                              pe.ToTable("StudentCoursesTable");
                          });
        }
