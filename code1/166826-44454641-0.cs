        public static string DropTrailingZeros(string test)
        {
            if (test.Contains(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator))
            {
                test = test.TrimEnd('0');
            }
            if (test.EndsWith(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator))
            {
                test = test.Substring(0,
                    test.Length - CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator.Length);
            }
            return test;
        }
