    public static void AbandonAndClearSessionCookie(this HttpSessionState session) {
        session.Clear();
        session.Abandon();
        if (HttpContext.Current != null && HttpContext.Current.Response != null)
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
    }
