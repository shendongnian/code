    /// <summary>
    /// Firm ID
    /// </summary>
    [ChineseDescription("送样单位编号")]
    [ValidRequired()]
    public string FirmGUID
    {
        get { return _firmGUID; }
        set { _firmGUID = value; }
    }
