            private static long UnformatBytes(string sizeInWords)
        {
            if(string.IsNullOrWhiteSpace(sizeInWords))
                return -1;
            string size = sizeInWords.Split(' ').FirstOrDefault();
            double result;
            if (string.IsNullOrWhiteSpace(size) || !double.TryParse(size, out result))
            {
                Debugger.Break();
                return -1;
            }
            int pow;
            if (sizeInWords.IndexOf("byte", StringComparison.OrdinalIgnoreCase) > -1)
                pow = 0;
            else if (sizeInWords.IndexOf("kb", StringComparison.OrdinalIgnoreCase) > -1)
                pow = 1;
            else if (sizeInWords.IndexOf("mb", StringComparison.OrdinalIgnoreCase) > -1)
                pow = 2;
            else if (sizeInWords.IndexOf("gb", StringComparison.OrdinalIgnoreCase) > -1)
                pow = 3;
            else if (sizeInWords.IndexOf("tb", StringComparison.OrdinalIgnoreCase) > -1)
                pow = 4;
            else
                return -1;
            
            return System.Convert.ToInt64((result * Math.Pow(1024, pow)));
        }
 
