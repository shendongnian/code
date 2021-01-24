    using (var ctx = new SchoolContext())
    {
        Grade[] grades = ctx.Grades.ToArray();
        Grade firstGrade = grades[0];
        Console.WriteLine(firstGrade.Students == null);  // True - as expected
        ctx.Grades.Detach(firstGrade); // stop tracking changes for this entity
        var students = ctx.Students.ToArray();
        Console.WriteLine(firstGrade.Students == null);  // True - still null
        // Let's reattach so we can track changes and save to database
        ctx.Grades.Attach(firstGrade);
        firstGrade.GradeName = "Some new value"; // will be persisted, as this is being tracked again
        ctx.SaveChanges();
    }
