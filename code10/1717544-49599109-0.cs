    public void Add(Job job)
    {
        var employee = Context.Employees.Find(job.Employee.Id);
        var project = Context.Projects.Find(job.Project.Id);
        Context.Jobs.Add(new Job { Employee = employee, Project = project, Time = job.Time });
    }
