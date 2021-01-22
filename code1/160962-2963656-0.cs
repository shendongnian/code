    private int _length;
    public int Length
    {
        get { return _length; }
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException("Length must be always positive. Please make sure the value is positive value.");
            }
            this._length = value;
        }
    }
