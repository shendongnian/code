    Project pr = new Project();
    pr.Milestones = new List<ProjectMilestone>();
    pr.Milestones.add(new ProjectMilestone());
    pr.Milestones.add(new ProjectMilestone());
    DataContext.InsertOnSubmit(pr);
    pr.SubmitChanges();
