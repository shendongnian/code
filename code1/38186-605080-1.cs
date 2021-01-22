    public void Index()
    {
      if (Request[Constants.QueryString.PostKey] == "eduncan911")
      {
        // do something
      }
    }
    
    public object GetPostsFromCache(int postID, int userID)
    {
      String cacheKey = String.Format(
          Constants.Cache.PagedPostList
          , userID
          , postID);
      return Cache[cacheKey] as IList<Post>;
    }
    
    
