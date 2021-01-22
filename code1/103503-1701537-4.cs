    public static void Application_OnError(Exception e)
    { /* ... */ }
    public static void Main()
    {
        try
        {
            /* ... */
        }
        catch (Exception e)
        {
            Application_OnError(e);
        }
    }
