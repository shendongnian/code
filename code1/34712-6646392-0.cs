    // timer is defined as a class member variable
    // so it doesn't go out of scope
    System.Threading.Timer timer;
    public void foo()
    {
        //
        // note the use of a lamda expression; 
        // you can add multiple lines of code here, or just call bar()
        //
        timer = new System.Threading.Timer(obj => { bar(); }, null, 1000, System.Threading.Timeout.Infinite);
    }
    
    public void bar()
    {
        // do stuff
    }
