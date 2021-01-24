    var dbRecords = repository.Get(userId); // However you are getting your records, do that here
    var result = dbRecords.GroupBy(x => x.UserId)
        .Select(g => new UserGroup
        {
            User = new User { UserName = g.First().UserName },
            Groups = g.Select(y => new Group { GroupName = y.GroupName }
        }
    );
