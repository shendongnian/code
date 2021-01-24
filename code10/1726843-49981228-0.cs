    public class Stopwatcher {
        private static readonly ConcurrentBag<StopwatcherData> _data = new ConcurrentBag<StopwatcherData>();
        public static void Track(Action action, string message) {
            var w = Stopwatch.StartNew();
            try {
                action();
            }
            finally {
                w.Stop();
                _data.Add(new StopwatcherData(w.ElapsedMilliseconds, message));
            }
        }
        public static T Track<T>(Func<T> func, string message) {
            var w = Stopwatch.StartNew();
            try {
                return func();
            }
            finally {
                w.Stop();
                _data.Add(new StopwatcherData(w.ElapsedMilliseconds, message));
            }
        }
    }
