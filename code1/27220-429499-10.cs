    public static class WS
    {
        private static object sync = new object();
        private static MyWebService _MyWebServiceInstance;
    	
        public static MyWebService MyWebServiceInstance
        {
            get
            {
                lock (sync)
                {
                    if (_MyWebServiceInstance == null)
                    {
                        _MyWebServiceInstance= new MyWebService();
                    }
                }
                return _MyWebServiceInstance;
            }
        }
    }
