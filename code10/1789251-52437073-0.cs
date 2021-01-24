    using (var ctx = new SchoolContext())
    {
        Grade[] grades = ctx.Grades.ToArray();
        Grade firstGrade = grades[0];
        ctx.Grades.Detach(grade);
        Console.WriteLine(grade.Students == null);  // True - As expected
        var students = ctx.Students.ToArray();
        Console.WriteLine(grade.Students == null);  // True - still null
    }
