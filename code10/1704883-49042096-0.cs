    // create global variable
    private int somevar;
    
    // create a sync object to lock
    private int _sync = new object();
    
    ...
    
    public void ItemRun()
    {   
        // make sure you lock it 
        // if there might be race conditions or you need thread safety
        lock(_sync)
        {
           // update your global variable
           somevar = 3;
        }
    }
    public void Return(object sender, KeyEventArgs e)
    {       
        // lock it again if you need to deal with race conditions
        // or thread safty
        lock(_sync)
        {
           Debug.WriteLine(somevar);
        }
    }
