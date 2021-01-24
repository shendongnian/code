    public bool ValidateUser(string user, string password)
    {
        var results = dbConnection.Table<User>().Where(v => v.uName == user && v.Pw = password).ToList();
        return (results.Count() > 0);
    }
