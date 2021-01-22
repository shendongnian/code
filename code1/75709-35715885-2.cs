    #if DEBUGNOSERVICE
    ...
    static void Main() 
    {
        Form     form;
    
        Application.EnableVisualStyles();
        Application.DoEvents();
    
        form = new <the name of the form>();
    
        Application.Run(form);
    }
    ...
    #endif
