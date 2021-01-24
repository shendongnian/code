        private static List<Task> Sort(Task[] tasks)
        {
            var completedTasks = new List<Task>();
            var uncompletedTasks = tasks.ToList();
            while (uncompletedTasks.Any())
            {
                var taskToComplete = uncompletedTasks
                    .FirstOrDefault(task => !task.Dependencies.Except(completedTasks.Select(x => x.Name)).Any());
                if (taskToComplete == null)
                {
                    // Cross dependency between tasks
                    Console.WriteLine($"Cross dependency between the tasks: {string.Join(", ", uncompletedTasks.Select(task => task.Name))}");
                    break;
                }
                completedTasks.Add(taskToComplete);
                uncompletedTasks.Remove(taskToComplete);
            }
            return completedTasks;
        }
