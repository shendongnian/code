    public static class MethodTimer
        {
            public static long Time(this Action action)
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                action();
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
        }
