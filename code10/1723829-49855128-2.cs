    var employeeWithActiveTaskCount = session
        .Query<Employee>()
        .Where(e => e.Id == id)
        .GroupJoin(
            session
                .Query<Task>()
                .Where(t => t.State == TaskState.Active),
            e => e.Id,
            t => t.Employee.Id,
            (e, t) => new { Employee = e, Tasks = t})
        .Select(et => new 
            {
                EmployeeId = et.Employee.Id,
                TaskCount = et.Tasks.Count() 
            });
