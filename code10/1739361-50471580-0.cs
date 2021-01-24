    class Program
    {
        static void Main(string[] args)
        {
            for (int index = 0; index < 20; ++index)
            {
                System.Threading.Thread.Sleep(349);
                DateTime value = DateTime.Now;
                DateTime rounded = value.RoundTo200thMillisecond();
                Console.WriteLine($"value = {value:yyyy-MM-dd HH:mm:ss.fff}, rounded = {rounded:yyyy-MM-dd HH:mm:ss.fff}");
            }
        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime RoundTo200thMillisecond(this DateTime value)
        {
            long elapsed = (long)((value - DateTime.MinValue).TotalMilliseconds);
            return DateTime.MinValue + TimeSpan.FromMilliseconds((elapsed + 100) / 200 * 200);
        }
    }
