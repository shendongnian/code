    public static double GetMyData(Dictionary<DateTime, double> MyData, DateTime Date)
    {
            var sorted = new SortedDictionary<DateTime, double>(MyData);
            var keys = new List<DateTime>(sorted.Keys);
            var index = keys.BinarySearch(Date);
            if (index >= 0) return sorted[keys[index]];
            else
                return sorted[keys[~index - 1]];
        }
