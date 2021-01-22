    public static DateTime  RoundUp(this DateTime dt, TimeSpan d)
    {
        return new DateTime(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
    }
    static ConcurrentDictionary<int, KeyValuePair<DateTime, string>> _concurrent = new ConcurrentDictionary<int, KeyValuePair<DateTime, string>>();
    
    /// <summary>
    /// This is an Elmah event used by the elmah engine when sending out emails. It provides an opportunity to weed out 
    /// irrelavent emails.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ErrorMail_Filtering(object sender, ExceptionFilterEventArgs e)
    {
        preventSpammingDigestEmail(e);
    }
    
    /// <summary>
    /// Prevents spamming by throttling emails to 5 minute intervals.
    /// </summary>
    /// <param name="e"></param>
    private static void preventSpammingDigestEmail(ExceptionFilterEventArgs e)
    {
        DateTime roundedTimeStamp = DateTime.Now.RoundUp(TimeSpan.FromMinutes(5));
        string serialisedException = Util.SerializeException(e.Exception);
    
        var lastRaisedException = new KeyValuePair<DateTime, string>
            (roundedTimeStamp, serialisedException);
    
        int key = lastRaisedException.GetHashCode();
    
        bool errorHasAlreadyBeenRaised = _concurrent.ContainsKey(key);
    
        // If event has already been raised in the last five minutes dont raise again
        if (errorHasAlreadyBeenRaised)
        {
            e.Dismiss();
            return;
        }
    
        // Record that it has been raised
        _concurrent.TryAdd(key, lastRaisedException);
    
        // Clean up existing entries
        Task.Factory.StartNew(() =>
            {
                var toRemove =
                    _concurrent.Where(pair => pair.Value.Key < DateTime.Now.Date).Select(pair => pair.Key).ToArray();
    
                foreach (var i in toRemove)
                {
                    KeyValuePair<DateTime, string> keyValuePair;
                    _concurrent.TryRemove(i, out keyValuePair);
                }
            });
    }
