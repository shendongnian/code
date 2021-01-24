    class TDest 
    {
        readonly ISomeInterface _someService;
        public string MyProperty { get; set; }
        public TDest(ISomeInterface someService)
        {
            _someService = someService;
        }
    }
