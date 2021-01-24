    IEnumerable<KeyValuePair<Guid, String>> users;
    users = _systemUserCommand.LookupUsersInRole(null, query)
                .Select(s =>new KeyValuePair<Guid, String>(
                    s.SystemUserId,
                    string.Format("{0} {1}", s.FirstName, s.LastName)
                ));
