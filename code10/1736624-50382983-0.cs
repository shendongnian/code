    var sessionDataQuery  = dbContext.Computers
        .Select(x => new 
        {
            x.Department.DepartmentId,
            x.Department.DepartmentName,
            x.ComputerId,
            ComputerName = x.Name,
            LoginEvents = x.EventLogs
                .OrderBy(e => e.EventDateTime)
                .Where(e => e.EventType = 11)
                .Select(e => new 
                {
                    e.EventId,
                    e.User.UserId,
                    e.User.UserName,
                    e.EventDateTime
                }.ToList(),
            LogoutEvents = x.EventLogs
                .OrderBy(e => e.EventDateTime)
                .Where(e => e.EventType = 12)
                .Select(e => new 
                {
                    e.EventId,
                    e.User.UserId,
                    e.User.UserName,
                    e.EventDateTime
                }.ToList()
         });
