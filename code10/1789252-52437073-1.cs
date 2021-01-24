    using (var ctx = new SchoolContext())
    {
        Grade[] grades = ctx.Grades.ToArray();
        Grade firstGrade = grades[0];
        ctx.Grades.Detach(grade);
        var students = ctx.Students.ToArray();
        ctx.Grades.Attach(grade);
        Console.WriteLine(grade.Students == null);  // True
        grade.GradeName = "Some new value"; // will be persisted, as this is being tracked again
        ctx.SaveChanges();
    }
