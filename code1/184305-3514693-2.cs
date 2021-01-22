    public interface IAPIWrapper
    {
        string UserID { get; }
        bool SessionHasExpired { get; }
        DateTime ExpirationDate { get; }
        void LogOut(); // expires the session & sets SessionHasExpired
    
        IAPISession RenewSession();
        IAPISession GetCurrentSession();
    }
    
    public static class IAPIWrapperImpl
    {
        private static Session session = new Session(); // Instantiate singleton here
        // This is an extension method for the IAPISession RenewSession method
        // the this keyword before the first parameter makes this an extension method
        public static IAPISession RenewSession(this IAPIWrapper wrapper)
        {
             // implementation details
             // use session here
        }
        // This is an extension method for the IAPISession GetCurrentSession method
        // the this keyword before the first parameter makes this an extension method
        public static IAPISession GetCurrentSession(this IAPIWrapper wrapper)
        {
             // implementation details
             // use session here
        }
    }
