    public static class Extensions
    {
        public static long Benchmark(this Action action)
        {
            return With.Benchmark(action);
        }
    }
