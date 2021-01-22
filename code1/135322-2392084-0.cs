    public class Foo
    {
        private static long instanceCount;
        public Foo()
        {
            // Increment in atomic and thread-safe manner
            Interlocked.Increment(ref instanceCount);
        }
    }
