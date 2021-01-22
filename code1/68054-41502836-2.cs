    public static class RandomExtensions
    {
        public static double NextDoubleMinMax(this Random random)
        {
            var size = sizeof(double);
            var bytes = new byte[size];
            while (true)
            {
                random.NextBytes(bytes);
                var value = BitConverter.ToDouble(bytes, 0);
                if (!double.IsNaN(value) && !double.IsInfinity(value))
                    return value;
            }
        }
    }
