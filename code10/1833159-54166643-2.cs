    return Context.Ad
            .Where(r.AdId == adId)
            Select(x => new 
                       { 
                          ad = x, 
                          IsFavourite = Context.Favourite.Any(y=> y.AdId = adId 
                                                        && y.UserId = currentUserid))
            .FirstOrDefault();
