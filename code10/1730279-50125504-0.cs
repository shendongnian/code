    public List<WebUserDTO> InsertUser (string Username, string UserPassword, string FullName, string Email)
    {
        _dataContext.WebUser_InsertUser(Username, UserPassword, FullName, Email);
        // since you did not provide _dataContext type definition
        // I can only guess how your user collection is called in your DbContext.
        return _dataContext.users.Select(aux => new WebUserDTO()
        {
            UserName = aux.Username,
            UserPassword = aux.UserPassword,
            FullName = aux.FullName,
            Email = aux.Email
        }).ToList();
    }
