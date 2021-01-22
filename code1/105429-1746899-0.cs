    public string Code
    {
        set
        {
            if (value.Length != 7)
            {
                throw new ArgumentOutOfRangeException(...)
            }
            // other validation
            _code = value;
        }
    }
