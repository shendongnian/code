    if (pagedCollection != null)
    {
        do
        {
            List<IUser> usersList = pagedCollection.CurrentPage.ToList();
            usersList = usersList.Where(x => !string.IsNullOrEmpty(x.Surname) && x.Surname.Contains("Peter"));
            pagedCollection = await pagedCollection.GetNextPageAsync();
        } 
        while (pagedCollection != null);
    }
