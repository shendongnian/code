    public static IEnumerable<Destination> ToDestinations(this IEnumerable<Task> tasks)
    {
        // make groups of tasks with same TaskId
        return tasks.GroupBy(task => task.TaskId,
           // from every found taskId, with all found Tasks with this taskId,
           // make one new Destination object
           (taskId, tasksWithThisTaskId) => new Destination
           {
                TaskId = taskId,
                Count = tasksWithThisTaskId.Count(),   // for Count: count all Tasks in this group
                TotalQuantity = tasksWithThisTaskId  // for TotalQuanty:
                     .Select(task => task.Quantity)  // extract the quantities of all tasks
                     .Sum(),                         // and Sum them
                ... // other destination properties, use either taskId, or the
                    // tasks with this taskId
        }
