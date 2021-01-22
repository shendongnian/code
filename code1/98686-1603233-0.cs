    public class BaseApp
    {
        public static Main(String[] args)
        {
            // TODO: ...
        }
    }
    public class App1 : BaseApp // Same for App2
    {
        // There is no need to keep a reference of the base class
        // if you are accessing static methods only
        public static Main(String[] args)
        {
            BaseApp.Main(args); // Access via class, not via instance
        }
    }
