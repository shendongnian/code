    [Obsolete("Please use the EyeOrientation property instead.")]
    private int _eyeOrientation;
    public int EyeOrientation
    {
        #pragma warning disable 612, 618
        get
        {
            return _eyeOrientation;
        }
        set
        {
            _eyeOrientation = (value > 0) ? value % 360 : 0;
        }
        #pragma warning restore 612, 618
    }
