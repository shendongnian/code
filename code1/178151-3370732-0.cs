    List<EduvisionUser> usersToRemove = new List<EduvisionUser>();
    foreach (EduvisionUser aUser in users) --->***Exception thrown in this line***
    {
        isUserAvailable = true;
        if(!aUser.Activated)
        {
            usersToRemove.Add(aUser);
        }
    }
    foreach (EduvisionUser userToRemove in usersToRemove)
    {
        users.Remove(userToRemove);
    }
