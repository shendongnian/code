    public void SomeMethod(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        if (value == string.Empty)
        {
            throw new ArgumentException("Value cannot be an empty string.", "value");
        }
    }
