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
        public static IAPISession RenewSession(this IAPIWrapper wrapper)
        {
             // implementation details
        }
    }
