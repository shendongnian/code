    public static int method()
    {
        Nullable<int> i = null;
        if (!i.HasValue)
            throw new NullReferenceException();
        else
            return 0;
    }
    public static void Main()
    {
        int? i = null;
        try
        {
            i = method();
        }
        catch (NullReferenceException ex)
        {
            i = null;
        }
        finally 
        {
            // null value stored in the i variable will be available
        }
    }
