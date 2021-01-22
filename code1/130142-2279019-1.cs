    var query = from action in db.Actions
                orderby action.CreatedOn descending
                group action by action.UserName into groupedActions
                let mostRecent = groupedActions.First()
                select new { UserName = groupedActions.Key,
                             LatestId = mostRecent.AuditId,
                             LatestAction = mostRecent.Action,
                             LatestDate = mostRecent.CreatedOn };
