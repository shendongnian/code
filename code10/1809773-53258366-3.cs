    var result = myDbContext.Departments
        .Where(department => ...)             // if you don't want all departments
        .Select(department => new
        {
            // select only the properties you plan to use
            Id = department.Id,
            Name = department.Name,
            StudentsWithHighGrades = department.Students
                .Where(student => student.Grade >= ...)
                .Select(student => new
                {
                    Id = student.Id,
                    Name = student.Name,
                    Grade = student.Grade,
                    ...
                })
                .ToList();
        });
