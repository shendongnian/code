        var tasks = _dbContext.Tasks
            .Include(i => i.RepeatConfig)
            .Where(p => p.RepeatTask && p.RepeatConfig != null && p.CopiedFromTaskId == null);
        if (tasks != null)
        {
            foreach (var task in tasks)
            {
                // I was calling the method here. 
            }
        }
