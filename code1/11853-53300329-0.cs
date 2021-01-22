        void Main()
        {
            var dateResult = GetRandomDates(new DateTime(1995, 1, 1), DateTime.UtcNow, 100);
            foreach (var r in dateResult)
                Console.WriteLine(r);
        }
        public static IList<DateTime> GetRandomDates(DateTime startDate, DateTime maxDate, int range)
        {
            var randomResult = GetRandomNumbers(range).ToArray();
            var calculationValue = maxDate.Subtract(startDate).TotalMinutes / int.MaxValue;
            var dateResults = randomResult.Select(s => startDate.AddMinutes(s * calculationValue)).ToList();
            return dateResults;
        }
        public static IEnumerable<int> GetRandomNumbers(int size)
        {
            var data = new byte[4];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider(data))
            {
                for (int i = 0; i < size; i++)
                {
                    rng.GetBytes(data);
                    var value = BitConverter.ToInt32(data, 0);
                    yield return value < 0 ? value * -1 : value;
                }
            }
        }
