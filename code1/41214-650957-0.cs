    public long GetUserId()
    {
      var user = GetUserAsync();
      return user.Id;
    }
