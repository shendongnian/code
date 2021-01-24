    /// <summary>
    /// How many engines flagged this resource.
    /// </summary>
    public int Positives { get; set; }
    /// <summary>
    /// The scan results from each engine.
    /// </summary>
    public Dictionary<string, UrlScanEngine> Scans { get; set; }
    /// <summary>
    /// How many engines scanned this resource.
    /// </summary>
    public int Total { get; set; }
