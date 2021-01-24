    var project = this.Projects.Include(x=>x.ProjectLeader)
      .Include(x=>x.EmployeesWorkingOnProject)
      .Include(x=>x.ProjectSteps)
      .SingleOrDefault(x=>x.ID == id); 
    return project; 
