    // In DoWork
    System.Globalization.CultureInfo before = System.Threading.Thread.CurrentThread.CurrentCulture;
    try
    
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = 
            new System.Globalization.CultureInfo("en-US");
     // Proceed with specific code
    }
    
    finally
    {
        System.Threading.Thread.CurrentThread.CurrentUICulture = before;
    }
