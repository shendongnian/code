    public static class ErrorCode
    {
        public const IDictionary<string, string> ErrorCodeDic;
        public static ErrorCode()
        {
            ErrorCodeDic = new Dictionary<string, string>()
                { {"1", "User name or password problem"} };
        }
    }
