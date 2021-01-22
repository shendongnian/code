    public void EnumerateEnum<T>()
    {
        int length = Enum.GetValues(typeof(T)).Length;
        for (var i = 0; i < length; i++)
        {
            var @enum = (T)(object)i;
        }
    }
