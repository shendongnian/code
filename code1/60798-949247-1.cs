    var tasksQuery = from task in ctx.Tasks
                 where task.IsActive
                 orderby task.Created
                 select task; // this is IQueryable<Task>
    Session["Tasts"] = tasksQuery.ToArray(); // this is Task[]
    ...
    var tasks = (Task[]) Session["Tasts"]; // this is Task[]
