    public long GetUserId()
    {
      User user = GetUserAsync();
      return user.Id;
    }
