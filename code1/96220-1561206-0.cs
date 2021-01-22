    public static IEnumerable<GetAllMyTasksResult> GetAllTasks()
    {
        using (MyTasksDataContext db = new MyTasksDataContext())
        {
            var tasks = db.GetAllMyTasks().Select(x => x).ToList();
            return tasks;
        }
    }
