    public static class NumberExtensions
    {
        private const string negativeWord = "negative";
        private static readonly Dictionary<ulong, string> _wordMap = new Dictionary<ulong, string>
        {
            [1_000_000_000_000_000_000] = "quintillion",
            [1_000_000_000_000_000] = "quadrillion",
            [1_000_000_000_000] = "trillion",
            [1_000_000_000] = "billion",
            [1_000_000] = "million",
            [1_000] = "thousand",
            [100] = "hundred",
            [90] = "ninety",
            [80] = "eighty",
            [70] = "seventy",
            [60] = "sixty",
            [50] = "fifty",
            [40] = "forty",
            [30] = "thirty",
            [20] = "twenty",
            [19] = "nineteen",
            [18] = "eighteen",
            [17] = "seventeen",
            [16] = "sixteen",
            [15] = "fifteen",
            [14] = "fourteen",
            [13] = "thirteen",
            [12] = "twelve",
            [11] = "eleven",
            [10] = "ten",
            [9] = "nine",
            [8] = "eight",
            [7] = "seven",
            [6] = "six",
            [5] = "five",
            [4] = "four",
            [3] = "three",
            [2] = "two",
            [1] = "one",
            [0] = "zero"
        };
    
        public static string ToWords(this short num)
        {
            var words = ToWords((ulong)Math.Abs(num));
            return num < 0 ? $"{negativeWord} {words}" : words;
        }
    
        public static string ToWords(this ushort num)
        {
            return ToWords((ulong)num);
        }
    
        public static string ToWords(this int num)
        {
            var words = ToWords((ulong)Math.Abs(num));
            return num < 0 ? $"{negativeWord} {words}" : words;
        }
    
        public static string ToWords(this uint num)
        {
            return ToWords((ulong)num);
        }
    
        public static string ToWords(this long num)
        {
            var words = ToWords((ulong)Math.Abs(num));
            return num < 0 ? $"{negativeWord} {words}" : words;
        }
    
        public static string ToWords(this ulong num)
        {
            var sb = new StringBuilder();
            var delimiter = String.Empty;
    
            void AppendWords(ulong dividend)
            {
                void AppendDelimitedWord(ulong key)
                {
                    sb.Append(delimiter);
                    sb.Append(_wordMap[key]);
                    delimiter = 20 <= key && key < 100 ? "-" : " ";
                }
                
                if (_wordMap.ContainsKey(dividend))
                {
                    AppendDelimitedWord(dividend);
                }
                else
                {
                    var divisor = _wordMap.First(m => m.Key <= dividend).Key;
                    var quotient = dividend / divisor;
                    var remainder = dividend % divisor;
    
                    if (quotient > 0 && divisor >= 100)
                    {
                        AppendWords(quotient);
                    }
    
                    AppendDelimitedWord(divisor);
    
                    if (remainder > 0)
                    {   
                        AppendWords(remainder);
                    }
                }
            }
    
            AppendWords(num);
            return sb.ToString();
        }    
    }
