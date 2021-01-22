    [Obsolete]
    private int _eyeOrientation;
    public int EyeOrientation
    {
        #pragma warning disable 0612
        get
        {
            return _eyeOrientation;
        }
        set
        {
            _eyeOrientation = (value > 0) ? value % 360 : 0;
        }
        #pragma warning restore 0612
    }
