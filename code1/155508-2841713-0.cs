    public abstract class TimeProvider
    {
        private static TimeProvider current;
        static TimeProvider()
        {
            TimeProvider.current = new DefaultTimeProvider();
        }
        //...
    }
