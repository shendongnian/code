     _cache.Set(cacheKey, cacheEntry, cacheEntryOptions);
    
    HttpCookie myCookie = new HttpCookie("yourCookieName");
    myCookie["cacheData"] = cacheEntry;
    myCookie.Expires = DateTime.Now.AddDays(1d);
    Response.Cookies.Add(myCookie);
