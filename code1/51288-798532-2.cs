    public static class MethodTimer
    {
        public static long Run(Action action)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            long time = MethodTimer.Run(() => File.Open(@"c:\test.txt", 
                FileMode.CreateNew));
            Console.WriteLine(time);
            Console.ReadLine();
        }
    }
