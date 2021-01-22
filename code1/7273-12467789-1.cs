    private void TimeFormats()
    {
        DateTime localTime = DateTime.Now;
        DateTime utcTime = DateTime.UtcNow;
        DateTimeOffset localTimeAndOffset = new DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset(localTime));
        //UTC
        string strUtcTime_o = utcTime.ToString("o");
        string strUtcTime_s = utcTime.ToString("s");
        string strUtcTime_custom = utcTime.ToString("yyyy-MM-ddTHH:mm:ssK");
        //Local
        string strLocalTimeAndOffset_o = localTimeAndOffset.ToString("o");
        string strLocalTimeAndOffset_s = localTimeAndOffset.ToString("s");
        string strLocalTimeAndOffset_custom = utcTime.ToString("yyyy-MM-ddTHH:mm:ssK");
        //Output
        Response.Write("<br/>UTC<br/>");
        Response.Write("strUtcTime_o: " + strUtcTime_o + "<br/>");
        Response.Write("strUtcTime_s: " + strUtcTime_s + "<br/>");
        Response.Write("strUtcTime_custom: " + strUtcTime_custom + "<br/>");
        Response.Write("<br/>Local Time<br/>");
        Response.Write("strLocalTimeAndOffset_o: " + strLocalTimeAndOffset_o + "<br/>");
        Response.Write("strLocalTimeAndOffset_s: " + strLocalTimeAndOffset_s + "<br/>");
        Response.Write("strLocalTimeAndOffset_custom: " + strLocalTimeAndOffset_custom + "<br/>");
    }
