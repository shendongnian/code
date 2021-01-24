    // never recreate the random class in your method
    // always just create one
    private static readonly Random _rand = new Random();
    
    // your variables, make them byte as that's what we are dealing with
    private static byte _r = 0;
    private static byte _g = 0;
    private static byte _b = 0;
    private static byte _a = 0;
    
    private static SomeMethod()
    {
    
        // make your life easier with some helper methods
        void Inc(ref byte val)
          => val = (byte)(val>=255 ? 0: val++);
        
        void Dec(ref byte val)
           => val = (byte)(val<=0 ? 255: val--);
        
        // not sure why you want this
        _a = (byte)_rand.Next(255);
        
        _r += 1;
        
        // i have no idea what your logic is here, but it looks neater
        // and wont overflow, which is your problem
        // however i seriously doubt this will give you a rainbow
        if (_r > 250)
        {
           Inc(ref _g);
           Dec(ref _r);
        }
        
        if (_g > 250)
        {
           Inc(ref _b);
           Dec(ref _g);
        }
        
        if (_b > 250)
        {
           Inc(ref _r);
           Dec(ref _b);
        } 
        
        lblMarquee.ForeColor = Color.FromArgb(_a, _r, _g, _b);
    
    }
