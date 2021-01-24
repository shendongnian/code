            Dictionary<Guid, string> users;
            users = _systemUserCommand.LookupUsersInRole(null, query)
            .ToDictionary(
                s => s.SystemUserId,
                s => string.Format("{0} {1}", s.FirstName, s.LastName)
            );
