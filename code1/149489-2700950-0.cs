    public class BusinessObject1
    {
        private static readonly object lockObject = new object();
    
        public static object SyncRoot { get { return lockObject; } }
    }
