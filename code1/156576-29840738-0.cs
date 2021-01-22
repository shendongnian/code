       internal static int XDateCompare(DateTime date, DateTime other, int ticks)
        {
            var diff = date.Ticks - other.Ticks;
            var result = Math.Abs(diff) <= ticks ? 0
                : diff <= 0 ? -1
                : 1;
            Console.WriteLine("{0}\t{1}\t{2}\ts={3} milSec={4}", diff, other, result, ticks, date.Subtract(other).Duration().TotalMilliseconds);
            return result;
        }
        internal static int XDateCompare(DateTime date, DateTime other, double milliseconds)
        {
            double diff =
                date.Subtract(other)
                .TotalMilliseconds;
            var result = Math.Abs(diff) <= milliseconds ? 0
                : diff <= 0 ? -1
                : 1;
            Console.WriteLine("result {0} diff {1} vs ms {2}", result, diff, milliseconds);
            return result;
        }
