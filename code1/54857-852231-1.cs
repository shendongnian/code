        class Task
        {
            public string Name { get; set; }
            public int Duration { get; set; }
        }
        class TaskList : List<Task>
        {
            public int Duration { get; set; }
            public void Add(Task task, int duration)
            {
                this.Add(task);
                Duration += duration;
            }
        }
        private static IList<TaskList> SplitTaskList(IList<Task> tasks, int topDuration)
        {
            IList<TaskList> subLists = new List<TaskList>();
            foreach (var task in tasks)
            {
                subLists = DistributeTask(subLists, task, topDuration);
            }
            return subLists;
        }
        private static IList<TaskList> DistributeTask(IList<TaskList> subLists, Task task, int topDuration)
        {
            if (task.Duration > topDuration)
                throw new ArgumentOutOfRangeException("task too long");
            if (subLists.Count == 0)
                subLists.Add(new TaskList());
            foreach (var subList in subLists)
            {
                if (task.Duration + subList.Duration <= topDuration)
                {
                    subList.Add(task, task.Duration);
                    return subLists;
                }
            }
            TaskList newList = new TaskList();
            newList.Add(task, task.Duration);
            subLists.Add(newList);
            return subLists;
        }
