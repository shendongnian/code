    public void UpdateProject(Project e)
    {
        var project = this.projects.Find(e.ProjectId);
        project.ProjectLeader.LeaderOfProject = null; // De-associate Employee A's project.
        //Copy values from e to project.
        project.StartDate = e.StartDate; // May be able to use CopyValues against Entity(project)... Would need to test. :)
    
        var employee = this.employees.Attach(e.ProjectLeader); // Attach employee B to this context.
        project.ProjectLeader = employee; // Associate Employee B to project, and project to employee B.
        employee.LeaderOfProject = project;
        this.SaveChanges();
    }
