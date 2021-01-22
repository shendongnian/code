    [DynamicQuery]
    public static Func<ActivityDataContext, int, IQueryable<ProjectObject>>
        GetCompiledLatestProjects = CompiledQuery.Compile
            ((ActivityDataContext db, int projectId) =>
             from c in db.projectObjects
             where c.projectId == projectId
             select c);
