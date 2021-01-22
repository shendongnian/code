    class Api
    {
        private static ErrorCode _result;
        private static ErrorCode Result
        {
            get { return _result; }
            set
            {
                _result = value;
                if (_result != ErrorCode.SUCCESS)
                {
                    throw Helper.ErrorToException(_result);
                }
            }
        }
    
        public static void NewMethod()
        {
            Result = Api.Method();
            Result = Api.Method2();
        }
    }
