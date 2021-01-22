    /// <summary>
    /// Returns the client (if available in cookie) or server timezone.
    /// </summary>
    public static int GetTimeZoneOffset(HttpRequest Request)
    {
        TimeZone tz = TimeZone.CurrentTimeZone;
        TimeSpan ts = tz.GetUtcOffset(DateTime.Now);
        int result = (int) ts.TotalMinutes;
        HttpCookie cookie = Request.Cookies["ClientTimeZone"];
        if (cookie != null)
            Int32.TryParse(cookie.Value, out result);
        return result;
    }
