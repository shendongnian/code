    private string[] _strStatus;
    private int[] _binStatus;
    public string[] strStatus
    {
        get
        {
            return _strStatus;
        }
        set
        {
            _strStatus = value;
            _binStatus = value.Select(v => v == "closed" ? 1 : 0).ToArray();
        }
    }
    public int[] binStatus
    {
        get
        {
            return _binStatus;
        }
        set
        {
            _binStatus = value;
            _strStatus = value.Select(v => v == 1 ? "closed" : "open").ToArray();
        }
    }
