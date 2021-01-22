    public static IEnumerable<GetAllMyTasksResult> GetAllTasks()
    {
        using (MyTasksDataContext db = new MyTasksDataContext())
        {
            return db.GetAllMyTasks().ToList();
        }
    }
