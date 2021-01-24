    public const string Feature1 = @"ft?.\s";
    public const string Feature2 = @"feat?.\s";
    public const string Feature3 = @"featuring\s";
    
    public const string Hyphen1 = "-";
    public const string Comma1 = ",";
    public const string And = "&";
    
    public const string BracketOpen1 = @"\(";
    public const string BracketOpen2 = @"\[";
    public const string BracketOpen3 = @"\{";
    
    public const string BracketClosed1 = @"\)";
    public const string BracketClosed2 = @"\]";
    public const string BracketClosed3 = @"\}";
    
    /// <summary>
    /// The words / Signs / Chars which indicate a new Artist / Feature / Title
    /// </summary>
    public static List<string> WordStopper = new List<string>()
    {
        Feature1, Feature2, Feature3,
        BracketOpen1, BracketOpen2, BracketOpen3,
        BracketClosed1, BracketClosed2, BracketClosed3,
        Hyphen1, Comma1
    };
    
    /// <summary>
    /// The start of a new feature
    /// </summary>
    public static List<string> FeatureBeginning = new List<string>()
    {
        Feature1,
        Feature2,
        Feature3
    };
    
    public static List<string> GetFeatures(string filename)
    {
        // Set the left side
        string starter = "(" + string.Join(")|(", FeatureBeginning.ToArray()) + ")";
    
        // Set the right side
        string stopper = "(" + string.Join(")|(", WordStopper.ToArray()) + ")";
    
        // Get the matches
        MatchCollection matches = Regex.Matches(filename, "(?<=(" + starter + "))(.+?)(?=(" + stopper + "))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
    
        return null;
    }
