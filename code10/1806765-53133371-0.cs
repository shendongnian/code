    using (var context = new DatabaseContext())
    {
        // Load all students and related classes
        var students1 = context.Students
                        .Include(s => s.Classes)
                        .ToList();
        // Load one student and its related classes
        var student1 = context.Students
                       .Where(s => s.Name == "someStudentName")
                       .Include(s => s.Classes)
                       .FirstOrDefault();
        // Load all students and related classes  
        // using a string to specify the relationship
        var students2 = context.Students
                        .Include("Classes")
                        .ToList();
        // Load one student and its related classes  
        // using a string to specify the relationship
        var student2 = context.Students
                       .Where(s => s.Name == "studentName")
                       .Include("Classes")
                       .FirstOrDefault();
    }
