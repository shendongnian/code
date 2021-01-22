    //C# replace C++ #define
    struct define
    {
        public const int BUFFER_SIZE = 1024;
        //public const int STAN_LIMIT = 6;
        //public const String SIEMENS_FDATE = "1990-01-01";
    }
    
    //some code
    byte[] buffer = new byte[define.BUFFER_SIZE];
