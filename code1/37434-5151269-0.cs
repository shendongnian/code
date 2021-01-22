    public class Something : ISomething
    {
        public Something(Action<DateTime> initializer)
        {
            var now = initializer();
        }
    }
