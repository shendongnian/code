    public static class TestFailureMethods
    {
        public static void Requires(bool condition, string userMessage, string conditionText)
        {
            if (!condition)
            {
                throw new PreconditionException(userMessage, conditionText);
            }
        }
    
        public static void Requires<TException>(bool condition, string userMessage, string conditionText) where TException : Exception
        {
            if (!condition)
            {
                throw new PreconditionException(userMessage, conditionText, typeof(TException));
            }
        }
    }
