    public static class StringHelper
    {
        private static readonly Random random = new Random();
        private const int randomSymbolsDefaultCount = 8;
        private const string availableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static int randomSymbolsIndex = 0;
        public static string GetRandomSymbols()
        {
            return GetRandomSymbols(randomSymbolsDefaultCount);
        }
        public static string GetRandomSymbols(int count)
        {
            var index = randomSymbolsIndex;
            var result = new string(
                Enumerable.Repeat(availableChars, count)
                          .Select(s => {
                              index += random.Next(s.Length);
                              if (index >= s.Length)
                                  index -= s.Length;
                              return s[index];
                          })
                          .ToArray());
            randomSymbolsIndex = index;
            return result;
        }
    }
