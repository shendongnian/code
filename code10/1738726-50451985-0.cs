      var eligibleUsers = await context.UserDetails
                .Where(a => (a.RegisteredDate >= DateTime.Now.AddDays(-28))   
                .Where(a => !a.IsAdminDisabled)
                .Where(a => !a.Tasks.Any(si=>si.taskName== query.taskName && si.status = 'Completed'))                 
                .Where(a => a.Tasks.Count(si => si.TaskInstance == query.AppName)<3)) 
                .Select(a=>a.UserID)
                .ToListAsync();
