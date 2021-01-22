    [Obsolete("Please don't touch the backing field!")]
    private int _backingField;
    public int YourProperty
    {
        #pragma warning disable 612, 618
        get { return _backingField; }
        set { _backingField = value; }
        #pragma warning restore 612, 618
    }
