    public static class RandomExtensions
    {
        public static double NextDoubleInMinMaxRange(this Random random)
        {
            var bytes = new byte[sizeof(double)];
            var value = default(double);
            while (true)
            {
                random.NextBytes(bytes);
                value = BitConverter.ToDouble(bytes, 0);
                if (!double.IsNaN(value) && !double.IsInfinity(value))
                    return value;
            }
        }
    }
