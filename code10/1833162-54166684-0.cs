    public object GetAd(long currentUser, long adId)
    {
        return from a in Context.Favourite
               where a.UserId  == currentUser
               select new {
                          flag = a.AdId != null
                          a.FavouriteId,
                          //etc
                          };
    }
