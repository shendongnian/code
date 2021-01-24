    Tquery = (
                 from tasks in context.Tasks.AsEnumerable()
                 select new Task()
                 {
                     TaskID = tasks.TaskID,
                     TaskName = tasks.TaskName,
                     TaskPath = tasks.TaskPath,
                     Schedules = tasks.Schedules
                 }
             )
             .ToDictionary
             (
                 task => task.TaskID //Create a dictionary using the TaskID as the key
             );
