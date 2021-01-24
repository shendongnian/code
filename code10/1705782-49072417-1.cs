        /// <summary>
        /// This method fill our listview with the list of users  
        /// </summary>
        private void FillUsersListView()
        {
            //We take an example of creating 3 users 
            User user1 = new User { ID = 1, Name = "Bettaieb" };
            User user2 = new User { ID = 2, Name = "Jhon" };
            User user3 = new User { ID = 3, Name = "Alex" };
            //We create a user list to use it later on the listview
            List<User> user_list = new List<User>();
            //We add the 3 users to the user_list
            user_list.Add(user1);
            user_list.Add(user2);
            user_list.Add(user3);
            //Finnaly we set the itemsource of ListView
            UserTableListView.ItemsSource = user_list;
        }
