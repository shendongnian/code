    internal static class Program
    {
        internal static void Main()
        {
            var results = GetDenominationValues();
            foreach (var result in results)
            {
                Console.WriteLine($"{result.Key} - {result.Value}");
            }
            Console.ReadLine();
        }
        private static Dictionary<int, int> GetDenominationValues()
        {
            var amount = 161;
            var denominations = new[] { 20, 10, 5, 1 };
            var results = new Dictionary<int, int>();
            foreach (var denomination in denominations)
            {
                results.Add(denomination, amount / denomination);
                amount = amount % denomination;
                if (amount == 0) break;
            }
            return results;
        }
    }
