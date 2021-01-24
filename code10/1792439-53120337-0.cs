    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<StudentGrade>()
                        .HasKey(s => new { s.GradeId , s.StudentId });
        var students= new[]
        {
         new Student{Id=1, Name="John"},
         new Student{Id=2, Name="Alex"},
         new Student{Id=3, Name="Tom"}
        }
    
        var grades = new[]
        {
         new Grade{Id=1, Grade=5},
         new Grad{Id=2,Grade=6}
        }
        var studentGrades = new[]
        {
         new StudentGrade{GradeId=1, StudentId=1},
         new StudentGrade{GradeId=2, StudentId=2},
         // Student 3 relates to grade 1 
         new StudentGrade{GradeId=1, StudentId=3}
        }
        modelBuilder.Entity<Student>().HasData(stdudents[0],students[1],students[2]);
        modelBuilder.Entity<Grade>().HasData(grades[0],grades[1]);
        modelBuilder.Entity<StudentGrade>().HasData(studentGrades[0],studentGrades[1],studentGrades[2]);
        base.OnModelCreating( modelBuilder );
    }
