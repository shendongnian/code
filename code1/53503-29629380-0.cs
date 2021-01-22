    string queryStr = Request.QueryString["diffInMinutes"];
    int diffInMinutes = 0;
    if (Int32.TryParse(queryStr, out diffInMinutes))
    {
        clientTime = serverTime.ToUniversalTime().AddMinutes(diffInMinutes);
    }
