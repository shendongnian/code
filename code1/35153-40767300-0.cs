    public static class NumberToWord
        {
            private static readonly Dictionary<long, string> MyDictionary = new Dictionary<long, string>();
    
            static NumberToWord()
            {
                MyDictionary.Add(1000000000000000, "quadrillion");
                MyDictionary.Add(1000000000000, "trillion");
                MyDictionary.Add(1000000000, "billion");
                MyDictionary.Add(1000000, "million");
                MyDictionary.Add(1000, "thousand");
                MyDictionary.Add(100, "hundread");
                MyDictionary.Add(90, "ninety");
                MyDictionary.Add(80, "eighty");
                MyDictionary.Add(70, "seventy");
                MyDictionary.Add(60, "sixty");
                MyDictionary.Add(50, "fifty");
                MyDictionary.Add(40, "fourty");
                MyDictionary.Add(30, "thirty");
                MyDictionary.Add(20, "twenty");
                MyDictionary.Add(19, "nineteen");
                MyDictionary.Add(18, "eighteen");
                MyDictionary.Add(17, "seventeen");
                MyDictionary.Add(16, "sixteen");
                MyDictionary.Add(15, "fifteen");
                MyDictionary.Add(14, "fourteen");
                MyDictionary.Add(13, "thirteen");
                MyDictionary.Add(12, "twelve");
                MyDictionary.Add(11, "eleven");
                MyDictionary.Add(10, "ten");
                MyDictionary.Add(9, "nine");
                MyDictionary.Add(8, "eight");
                MyDictionary.Add(7, "seven");
                MyDictionary.Add(6, "six");
                MyDictionary.Add(5, "five");
                MyDictionary.Add(4, "four");
                MyDictionary.Add(3, "three");
                MyDictionary.Add(2, "two");
                MyDictionary.Add(1, "one");
                MyDictionary.Add(0, "zero");
            }
    
            /// <summary>
            /// To the verbal.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns></returns>
            public static string ToVerbal(this int value)
            {
                return ToVerbal((long) value);
            }
    
            /// <summary>
            /// To the verbal.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <returns></returns>
            public static string ToVerbal(this long value)
            {
                if (value == 0) return MyDictionary[value];
    
                if (value < 0)
                    return $" negative {ToVerbal(Math.Abs(value))}";
    
                var builder = new StringBuilder();
                
                for (var i = 1000000000000000; i >= 1000; i = i/1000)
                    value = ConstructWord(value, builder, i);
    
                value = ConstructWord(value, builder, 100);
    
                for (var i = 90; i >= 20; i = i - 10)
                    value = ConstructWordForTwoDigit(value, builder, i);
    
                if (MyDictionary.ContainsKey(value))
                    builder.AppendFormat("{0}" + MyDictionary[value], builder.Length > 0 
                        ? " " 
                        : string.Empty);
    
                return builder.ToString();
            }
    
            private static long ConstructWord(long value, StringBuilder builder, long key)
            {
                if (value >= key)
                {
                    var unit = (int) (value/key);
                    value -= unit*key;
                    builder.AppendFormat(" {0} {1} " + MyDictionary[key], builder.Length > 0
                        ? ", "
                        : string.Empty, ToVerbal(unit));
                }
                return value;
            }
            private static long ConstructWordForTwoDigit(long value, StringBuilder builder, long key)
            {
                if (value >= key)
                {
                    value -= key;
                    builder.AppendFormat(" {0} " + MyDictionary[key], builder.Length > 0
                        ? " "
                        : string.Empty);
                }
                return value;
            } 
        }
