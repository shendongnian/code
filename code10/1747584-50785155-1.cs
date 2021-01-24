    public class DefaultPrinter
    {
        private int defaultTimes = 10;
        public void ExecuteMethod(Action<string, int> action, string output)
        {
            action(output, defaultTimes);
        }
    }
