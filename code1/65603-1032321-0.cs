    class Car 
    {
        public void SetLookupProvider(ILookupProvider value) { _lookupProvider = value; }
        public IMakeInfo Make { get { return _lookupProvider.ResolveMake(MakeId); } }
        ....
    }
    interface ILookupProvider
    {
        IMakeInfo ResolveMake(int id);
    }
    class LookupProvider
    {
        public delegate IMakeInfo ResolveMakeDelegate(int id);
        public ResolveMakeDelegate ResolveMakeDel { set { _resolvemake = value; } }
        public IMakeInfo ResolveMake(int id){ return _resolvemake(id); }  
    }
