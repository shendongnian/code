    [LoaderOptimization(LoaderOptimization.MultiDomain)]
    static public void Main(string[] args)
    {
       
        // To load our assembly appdomain neutral we need to use MultiDomain on our hosting and child domain
        // If not we would get different Method tables for the same types which would result in InvalidCastExceptions
        // for the same type.
        var other = AppDomain.CreateDomain("Test"+i.ToString(), AppDomain.CurrentDomain.Evidence, new AppDomainSetup
            {
                LoaderOptimization = LoaderOptimization.MultiDomain,
            });
    
        // Create gate object in other appdomain
        DomainGate gate = (DomainGate)other.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(DomainGate).FullName);
        
        // now lets create some data
        CrossDomainData data = new CrossDomainData();
        data.Input = Enumerable.Range(0, 10).ToList();
    
        // process it in other AppDomain
        DomainGate.Send(gate, data);
    
        // Display result calculated in other AppDomain
        Console.WriteLine("Calculation in other AppDomain got: {0}", data.Aggregate);
        }
    }
