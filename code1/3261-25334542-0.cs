        private int[] ParseRange(string ranges)
        { 
            string[] groups = ranges.Split(',');
            return groups.SelectMany(t => GetRangeNumbers(t)).ToArray();
        }
        private int[] GetRangeNumbers(string range)
        {
            //string justNumbers = new String(text.Where(Char.IsDigit).ToArray());
            int[] RangeNums = range
                .Split('-')
                .Select(t => new String(t.Where(Char.IsDigit).ToArray())) // Digits Only
                .Where(t => !string.IsNullOrWhiteSpace(t)) // Only if has a value
                .Select(t => int.Parse(t)) // digit to int
                .ToArray();
            return RangeNums.Length.Equals(2) ? Enumerable.Range(RangeNums.Min(), (RangeNums.Max() + 1) - RangeNums.Min()).ToArray() : RangeNums;
        }
