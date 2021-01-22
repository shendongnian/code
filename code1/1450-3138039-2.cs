    [Test, Category("ProfileEntity")]
    public void MyTest()
    {
        // this is the object that we want profiled.
        // we would normally pass this around and call
        // methods on this instance.
        DALToBeProfiled dal = new DALToBeProfiled();
    
        // To profile, instead we obtain our proxy
        // and pass it around instead.
        DALToBeProfiled dalProxy = (DALToBeProfiled)EntityProfiler.Instance(dal);
       
        // or...
        DALToBeProfiled dalProxy2 = EntityProfiler<DALToBeProfiled>.Instance(dal);
    
        // Now use proxy wherever we would have used the original...
        // All methods' timings are automatically recorded
        // with a high-resolution timer
        DoStuffToThisObject(dalProxy);
    
        // Output profiling results
        ProfileManager.Instance.ToConsole();
    }
