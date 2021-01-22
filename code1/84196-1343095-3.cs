    public static void Frob(Exception ex)
    {
        if (Debugger.IsAttached)
        {
            Debugger.Break();
        }
    }
