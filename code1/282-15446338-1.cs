    public string RelativeDateTimeCount(DateTime inputDateTime)
    {
        string outputDateTime = string.Empty;
        TimeSpan ts = DateTime.Now - inputDateTime;
        if (ts.Days > 7)
        { outputDateTime = inputDateTime.ToString("MMMM d, yyyy"); }
        else if (ts.Days > 0)
        {
            outputDateTime = ts.Days == 1 ? ("about 1 Day ago") : ("about " + ts.Days.ToString() + " Days ago");
        }
        else if (ts.Hours > 0)
        {
            outputDateTime = ts.Hours == 1 ? ("an hour ago") : (ts.Hours.ToString() + " hours ago");
        }
        else if (ts.Minutes > 0)
        {
            outputDateTime = ts.Minutes == 1 ? ("1 minute ago") : (ts.Minutes.ToString() + " minutes ago");
        }
        else outputDateTime = "few seconds ago";
        return outputDateTime;
    }
  
