    class RandomDates
    {
        private Random random = new Random();
        public DateTime Date(DateTime? start = null, DateTime? end = null)
        {
            if (start.HasValue && end.HasValue && start.Value >= end.Value)
                throw new Exception("start date must be less than end date!");
            DateTime min = start ?? DateTime.MinValue;
            DateTime max = end ?? DateTime.MaxValue;
            // for timespan approach see: http://stackoverflow.com/q/1483670/1698987
            TimeSpan timeSpan = max - min;
            // for random long see: http://stackoverflow.com/a/677384/1698987
            byte[] bytes = new byte[8];
            random.NextBytes(bytes);
            long int64 = Math.Abs(BitConverter.ToInt64(bytes, 0)) % timeSpan.Ticks;
            TimeSpan newSpan = new TimeSpan(int64);
            return min + newSpan;
        }
    }
