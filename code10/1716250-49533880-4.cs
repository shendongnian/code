    public static class Helper
    {
        public static TException GetInnerException<TException>(this Exception ex) where TException : Exception
        {
             return ex.InnerException != null 
                 ? ex.InnerException as TException ?? GetInnerException<TException>(ex.InnerException)
                 : null;
        }
    }
