    public static void CreateUsers() 
    {
        for (int i = 0; i < numberOfUsers; i++)
        {
            systemUsers.Add(new User(usernames[i]) { FirstName = firstNames[i], LastName = lastNames[i] });
        }
    }
