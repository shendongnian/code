    static class Extensions
    {
        public static void DoIt(this IAInterface ia)
        {
            ia.AInterfaceMethod(); // no cast here!
        }
    }
    ...
    void AnotherMethod()   
    {      
        this.DoIt();  // no cast here either!
    }
