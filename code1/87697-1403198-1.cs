    public StringReader(string s)
    {
        if (s == null)
        {
            throw new ArgumentNullException("s");
        }
        this._s = s;
        this._length = (s == null) ? 0 : s.Length;
    }
