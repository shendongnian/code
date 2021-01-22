    // singleton
    private static MyObjectContext context;
    public static MyObjectContext getInstance()
    {
        if (context == null)
        {
            context = new MyObjectContext ();
        }
        return context;
    } 
