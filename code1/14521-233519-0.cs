      public static class Test {
        public static void Invoke() {
            using( SingleTimer.Start )
                Thread.Sleep( 200 );
            Console.WriteLine( SingleTimer.Elapsed );
            using( SingleTimer.Start ) {
                Thread.Sleep( 300 );
            }
            Console.WriteLine( SingleTimer.Elapsed );
        }
    }
    public class SingleTimer :IDisposable {
        private Stopwatch stopwatch = new Stopwatch();
        public static readonly SingleTimer timer = new SingleTimer();
        public static SingleTimer Start {
            get {
                timer.stopwatch.Reset();
                timer.stopwatch.Start();
                return timer;
            }
        }
        public void Stop() {
            stopwatch.Stop();
        }
        public void Dispose() {
            stopwatch.Stop();
        }
        public static TimeSpan Elapsed {
            get { return timer.stopwatch.Elapsed; }
        }
    }
