        public int GetIndex(string input)
        {
            input = input.ToUpper();
            char low = input[input.Length - 1];
            char? high = input.Length == 2 ? input[0] : (char?)null;
            int indexLow = low - 'A';
            int? indexHigh = high.HasValue ? high.Value - 'A' : (int?)null;
            return (indexHigh.HasValue ? (indexHigh.Value + 1) * 26 : 0) + indexLow;
        }
