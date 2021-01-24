    static void Main()
    {
        var decaultConstr = new IOwnNothing(); //valid
        var customConst = new IOwnAParamConstructor(); // invalid
        var customConst2 = new IOwnAParamConstructor(6); //valid
        var privateConstr = new IOwnAPrivateParamConstructor(); //no constructor available
    }
    
    private class IOwnNothing
    {
    }
    
    private class IOwnAParamConstructor
    {
        public IOwnAParamConstructor(int a) { }
    }
    
    private class IOwnAPrivateParamConstructor
    {
        private IOwnAPrivateParamConstructor(int a) { }
    }
