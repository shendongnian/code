    using (var userAdapter = new UserTableAdapter())
                {
                    var users = userAdapter.GetData();
    
                    userAdapter.DeleteAll();
                    users.Clear();    
    
                    PopulateUsers(users, userAdapter);
                    PrintData(users);
    
                    var user1 = users.Single(user => user.Name == "user1");
                    var user2 = users.Single(user => user.Name == "user2");
        
                    user1.Delete(); 
                    user2.Name = "user3";
                    
                    userAdapter.Update(users);
    
                    PrintData(users);
                }
