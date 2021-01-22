    model.TaskCountByAssignee = (
            (from t in TaskRepository.List()
             from tu in t.TaskUsers
             group tu by tu.UserName into tug
             select new {Count = tug.Count(), UserName = tug.Key})
            .Union(from t in TaskRepository.List()
                   where !t.TaskUsers.Any()
                   group t by 1 into tug
                   select new {Count = tug.Count(), UserName = null}).ToList();
