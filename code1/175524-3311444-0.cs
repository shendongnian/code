    public static class ExceptionExtensions
    {
        public static String ToMyString(this Exception ex)
        {
    #if DEBUG
            return ex.ToString();
    #else
            return ex.Message;
    #endif
        }
    }
