    public abstract class BaseException : ApplicationException
    {
        static ResourceManager defaultManager;
        static ResourceManager DefaultManager
        {
            get
            {
                if (defaultManager == null) defaultManager = TODO; // sensible default
                return defaultManager;
            }
        }
    
        public BaseException(System.Enum errorCode, params object[] messageArgs)
            : this(DefaultManager, errorCode, messageArgs) {}
        public BaseException(ResourceManager resourceManager, System.Enum errorCode, params object[] messageArgs)
            : base(ProcessError(resourceManager, errorCode, messageArgs))
        { }
    
        private static string ProcessError(ResourceManager resourceManager, Enum errorCode, params object[] messageArgs)
        {
            if (resourceManager == null) throw new ArgumentNullException("resourceManager");
            string errorMessage = resourceManager.GetString(errorCode.ToString());
            // Handling of messageArgs and trace logging
            // ....
            return finalString;
        }
    }
