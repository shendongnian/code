    public static class ErrorHandler
    {
        public static void WriteAndThrow(string msg)
        {
            Debug.WriteLine(msg);
            throw;
        }
    }
