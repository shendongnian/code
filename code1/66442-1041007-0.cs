    // get the entities that have been inserted or modified
    var projects = ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified).Where(x => x.Entity is Project).Select( x=> (Project) x.Entity);
    // get existing entities, exclude those that are being modified
    var projects2 = this.Projects.Where(BuildDoesntContainExpression<Project, int>(z => z.ProjectId, projects.Select(x => x.ProjectId)));
    // Union the 2 sets
    var projects3 = projects.Union(projects2);
