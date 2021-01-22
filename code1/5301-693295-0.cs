    static void Main(string[] args)
    {
         
        {       
                    AppDomain ad = AppDomain.CreateDomain("NewDomain");
                    Managed c = ad.CreateInstanceAndUnwrap(a.FullName, typeof(Managed).FullName) as Managed;
                    int val2 = c.CallLibFunc();
                    //  Value is zero
        
                   AppDomain.Unload(ad)
        }
        {       
                    AppDomain ad = AppDomain.CreateDomain("NewDomain");
                    Managed c = ad.CreateInstanceAndUnwrap(a.FullName, typeof(Managed).FullName) as Managed;
                    int val2 = c.CallLibFunc();
                    //  I think value is zero
        
                   AppDomain.Unload(ad)
        }
    
    
    }
    `
