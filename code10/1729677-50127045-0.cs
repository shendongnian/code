    var commentItem = new Comment
    {
        User = GetCurrentUserExtData(),
        Content = NewCommentText
    }
    public User GetCurrentUserExtData(string ID = null)
    {
        var user = new User();
        var data = DataStore.GetUser(ID);
        data.Wait();
        user = data.Result;
        return user;
    }
