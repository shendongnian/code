    using (var context = new DatabaseContext())
    {
        // Load all students and related classes
        var classes1 = context.Classes
                        .Include(s => s.Students)
                        .ToList();
        // Load one student and its related classes
        var classt1 = context.Classes
                       .Where(s => s.Name == "someClassName")
                       .Include(s => s.Students)
                       .FirstOrDefault();
        // Load all students and related classes  
        // using a string to specify the relationship
        var classes2 = context.Classes
                        .Include("Students")
                        .ToList();
        // Load one student and its related classes  
        // using a string to specify the relationship
        var class2 = context.Classes
                       .Where(s => s.Name == "someName")
                       .Include("Students")
                       .FirstOrDefault();
    }
