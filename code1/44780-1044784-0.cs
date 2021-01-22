    struct Task { int work, progress  }
    class OverallProgress
    {
        List<Task> tasks;
        int Work { get { return tasks.Sum(t=>t.work; } }
        int Progress { get { return tasks.Sum(t=>t.progress/t.work); } }
        void AddTask(Task t) { tasks.Add(t); }
    }
