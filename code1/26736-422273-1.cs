    public class ServiceFactory
    {
        public static IYourBusinessService GetService()
        {
            //you can set any addition info here
            //like connection string for db, etc.
            return new YourBusinessService();
        }
    }
