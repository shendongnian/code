    private static readonly List<string> SortingOrder =
       new List<string>()
       {
            { "Fall" },
            { "Spring" },
            { "Summer" }
       };
    
    using (var context = new EUContext())
    {
        // this part will query the database
        var tmp = context.Terms
                         .Include(x=>x.TermCourses)
                         .Where(x => x.StudentID == studentId && x.DepartmentID == departmentId)
                         // this will transfer controll to your local machine
                         .AsEnumerable() 
                         // sort on your local machine by the data you have in your RAM
                         .OrderBy(x => x.AcademicYear)
                         .ThenBy(x => SortingOrder.IndexOf(x.TermRegistered));
    
        return tmp.ToList();
    }
