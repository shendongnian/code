    /// <summary>
    /// Returns the client (if available in cookie) or server timezone.
    /// </summary>
    public static int GetTimeZoneOffset(HttpRequest Request)
    {
        // Default to the server time zone
        TimeZone tz = TimeZone.CurrentTimeZone;
        TimeSpan ts = tz.GetUtcOffset(DateTime.Now);
        int result = (int) ts.TotalMinutes;
        // Then check for client time zone (minutes) in a cookie
        HttpCookie cookie = Request.Cookies["ClientTimeZone"];
        if (cookie != null)
        {
            int clientTimeZone;
            if (Int32.TryParse(cookie.Value, out clientTimeZone))
                result = clientTimeZone;
        }
        return result;
    }
