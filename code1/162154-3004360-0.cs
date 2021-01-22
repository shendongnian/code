    class Program {
        const int MAX_ERROR_IN_MILLISECONDS = 20;
        const int ONE_SECOND = 1000;
        const int HALF_SECOND = ONE_SECOND / 2;
        private static System.Threading.Timer timer;
        static void Main(string[] args) {
            timer = new System.Threading.Timer(Tick);
            timer.Change(ONE_SECOND - DateTime.Now.Millisecond, ONE_SECOND);
            Console.ReadLine();
        }
        private static int ticksSynced = 0;
        private static int currInterval = ONE_SECOND;
        private static void Tick(object s) {
            var ms = DateTime.UtcNow.Millisecond;
            var diff = ms > HALF_SECOND ? ms - ONE_SECOND : ms;
            if (Math.Abs(diff) < MAX_ERROR_IN_MILLISECONDS) {
                // still synced
                ticksSynced++;
            } else {
                // Calculate new interval
                currInterval -= diff / ticksSynced;
                timer.Change(ONE_SECOND - ms, currInterval);
                Console.WriteLine("New interval: {0}; diff: {1}; ticks: {2}", currInterval, diff, ticksSynced);
                ticksSynced = 0;
            }
            Console.WriteLine(ms);
        }
    }
