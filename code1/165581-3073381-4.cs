    public class Billing
    {
        private Dictionary<DateTime, PrecalculateValue> Values = 
            new Dictionary<DateTime, PrecalculateValue>();
        private readonly commonLockObject = new object();
        public int GetValue(DateTime date)
        {
            PrecalculateValue cachedCalculation;
            
            // Note: for true thread safety, you need to lock reads as well as
            // writes, to ensure that a write happening concurrently with a read
            // does not corrupt state.
            lock (commonLockObject) {
                if (Values.TryGetValue(date, out cachedCalculation))
                    return cachedCalculation.value;
            }
            int value = GetValueFor(date);
            
            // Here we need to check if the key exists again, just in case another
            // thread added an item since we last checked.
            // Also be sure to lock ANYWHERE ELSE you're manipulating
            // or reading from the collection.
            lock (commonLockObject) {
                if (!Values.ContainsKey(date))
                    Values[date] = new PrecalculateValue{date = date, value = value};
            }
            return value;
        }
        private object GetValueFor(DateTime date)
        {
            //some logic here
        }
    }
