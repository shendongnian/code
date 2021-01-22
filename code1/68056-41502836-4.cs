    public static class RandomExtensions
    {
        public static double NextDoubleMinMax(this Random random)
        {
            var size = sizeof(double);
            var bytes = new byte[size];
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
