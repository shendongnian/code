    public static void CheckNotNull(object x, object y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException();
        }
    }
    // etc
