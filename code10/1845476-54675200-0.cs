      var users = await graphClient.Users.Request().GetAsync();
    try
        {
            while (users != null)
            {
                var usersList = users.CurrentPage.ToList();
                count = count + usersList.Count();
                users = await users.NextPageRequest.GetAsync();
            }
        }
        catch
        {
            //
        }
 
