    //select users
    Dictionary<int, User> users = new Dictionary<int, User>();
    foreach (User user in selectUsersFromDatabase())
    {
      users.Add(user.Id, user);
    }
    //select groups
    Dictionary<int, Group> group = new Dictionary<int, Group>();
    foreach (Group group in selectGroupsFromDatabase())
    {
      groups.Add(group.Id, group);
    }
    //select relations
    //and join groups to users
    //and join users to groups
    foreach (Relation relation in selectRelationsFromDatabase())
    {
      //find user in dictionary
      User user = users[relation.userId];
      //find group in dictionary
      Group group = groups[relation.groupId];
      //add group to user and add user to group
      user.BelongsTo.Add(group);
      group.Users.Add(user);
    }
