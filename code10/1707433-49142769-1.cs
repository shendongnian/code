        public static string Get(int currentValue)
        {
            var last = categories.Last(m => m.Min < currentValue);
    //if the list is ordered 
    //or
    // var last = categories.FirstOrDefault(m => m.Min <= currentValue && m.Max >= currentValue);
            return last?.Name;
        }
