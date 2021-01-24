    public static void CreateUsers() 
                {
                    User currentUser = null;
                    // loop over the num. of users
                    for (int i = 0; i < numberOfUsers; i++)
                    {
                        // create new user
                        currentUser = new User(usernames[i]);
                        systemUsers.Add(currentUser);
                        currentUser.FirstName = firstNames[i];
                        currentUser.LastName = lastNames[i];
    
                    }
                }
