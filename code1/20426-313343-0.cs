    public static class ErrorCode
    {
        public static IDictionary<string, string> ErrorCodeDic;
         static ErrorCode()
        {
            ErrorCodeDic = new Dictionary<string, string>()
                { {"1", "User name or password problem"} };
        }
    }
