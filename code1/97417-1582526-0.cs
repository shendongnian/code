        private static IEnumerable<int> SixDigitNumbers = Enumerable.Range(100000, (999999 - 100000));
        private static IEnumerable<int> Multipliers = Enumerable.Range(2, 8);
        static void Main(string[] args)
        {
            var Solutions = from OriginalNumber in SixDigitNumbers
                                  from Multiplier in Multipliers
                                  let MultipliedNumber = (OriginalNumber * Multiplier)
                                  where MultipliedNumber < 999999 && ResultIsNumericPalindrome(OriginalNumber, Multiplier)
                                  select new { MultipliedNumber, OriginalNumber, Multiplier };
            var AllSolutions = Solutions.ToList();
        }
        private static string Reverse(string Source)
        {
            return new String(Source.Reverse().ToArray());
        }
        private static bool ResultIsNumericPalindrome(int Original, int Multiplier)
        {
            return (Original.ToString() == Reverse((Original * Multiplier).ToString()));
        }
    
