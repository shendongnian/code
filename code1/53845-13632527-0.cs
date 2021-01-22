    static class ExcelHeaderHelper
    {
        public static string[] GetHeaderLetters(uint max)
        {
            var result = new List<string>();
            int i = 0;
            var columnPrefix = new Queue<string>();
            string prefix = null;
            int prevRoundNo = 0;
            uint maxPrefix = max / 26;
            
            while (i < max)
            {
                int roundNo = i / 26;
                if (prevRoundNo < roundNo)
                {
                    prefix = columnPrefix.Dequeue();
                    prevRoundNo = roundNo;
                }
                string item = prefix + ((char)(65 + (i % 26))).ToString(CultureInfo.InvariantCulture);
                if (i <= maxPrefix)
                {
                    columnPrefix.Enqueue(item);
                }
                result.Add(item);
                i++;
            }
            return result.ToArray();
        }
    }
