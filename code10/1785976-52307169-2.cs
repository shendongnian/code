    public static void CreateUsers() 
                {
                    //make sure currentUser variable is declared outside the loop
                    //or inside the loop at start of the loop body 
                    User currentUser = null;
                   //make sure your systemUsers binding list is not null
                    if(systemUsers == null) {
                        systemUsers = new BindingList<User>();
                    }
                    // loop over the num. of users
                    for (int i = 0; i < numberOfUsers; i++)
                    {
                        // create new user
                        currentUser = new User(usernames[i]);
                        currentUser.FirstName = firstNames[i];
                        currentUser.LastName = lastNames[i];
                       //add the User object to your list
                        systemUsers.Add(currentUser);
         
                    }
                }
