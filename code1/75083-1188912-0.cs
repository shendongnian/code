    private static DateTime _lastSyncDate;
    public static DateTime LastSyncDate
    {
        get { return _lastSyncDate; }
        set { _lastSyncDate = value;}
    }
    public static string LastSyncDateString
    {
        get { return LastSyncDate.ToString("MM/dd/yyyy"); }
    }
