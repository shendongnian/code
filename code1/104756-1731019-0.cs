    public class MyConsumer
    {
        static MyConsumer()
        {
            Factory.Resolve<Singleton>().DoWork += WorkMethod;
        }
        private static void WorkMethod(...) { ... }
    }
