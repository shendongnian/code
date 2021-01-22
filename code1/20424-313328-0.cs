    public static class ErrorCode
    {
        public const IDictionary<string , string > m_ErrorCodeDic;
    
        public static ErrorCode()
        {
          m_ErrorCodeDic = new Dictionary<string, string>()
                 { {"1","User name or password problem"} };             
        }
    }
