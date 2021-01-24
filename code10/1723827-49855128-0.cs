    var employeeWithActiveTasks = session
        .Query<Employee>()
        .Where(e => e.Id == id)
        .Select(e => new 
            {
                EmployeeId = e.Id,
                TaskCount = e.Tasks.Count()
            });
