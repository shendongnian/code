    var result = universityDbContext.Students
        .Where(student => ...)                 // only if you don't want all Students
        .Select(student => new
        {
            // select only the properties you plan to use
            Id = student.Id,
            StudentName = student.Name,
            DepartmentName = student.Department.Name,
        });
