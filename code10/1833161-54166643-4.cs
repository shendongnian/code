    return Context.Ad
                .Where(r.AdId == adId)
                .ToList()
                Select(x => new UserFavouriteAd 
                           { 
                              ad = x, 
                              IsFavourite = Context.Favourite.Any(y=> y.AdId = adId 
                                                            && y.UserId = currentUserid))
                .FirstOrDefault();
