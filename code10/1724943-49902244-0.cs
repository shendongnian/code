        if (pagedCollection != null)
        {
            do
            {
                List<IUser> usersList = pagedCollection.CurrentPage.ToList();
        
                var filteredUsersList = usersList.Where(x => !string.IsNullOrEmpty(x.Surname) && x.Surname.Contains("Peter"));
        
                foreach (IUser user in filteredUsersList)
                {
                    userList.Add((User) user);
                }
                pagedCollection = await pagedCollection.GetNextPageAsync();
            } 
            while (pagedCollection != null);
    }
