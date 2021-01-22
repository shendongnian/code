    public static class Extensions
    {
        public static long Benchmark(this Action action)
        {
            return With.Benchmark(action);
        }
        public static Action Iterations(this Action action, int n)
        {
            return () => With.Iterations(n, action);
        }
    }
