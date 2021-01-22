    public class Billing
    {
        private Dictionary<DateTime, PrecalculateValue> Values = 
            new Dictionary<DateTime, PrecalculateValue>();
        private readonly commonLockObject = new object();
        public int GetValue(DateTime date)
        {
            PrecalculateValue cachedCalculation;
            
            // note: for true thread safety, you'd really need to lock this entire
            // read/write operation, as otherwise you could have two threads both
            // see that an item is not in the collection, and then both attempt to
            // add an item to it
            lock (commonLockObject) {
                if (Values.TryGetValue(date, out cachedCalculation))
                    return cachedCalculation.value;
                // unfortunately, that does mean this calculation needs to be
                // locked as well...
                int value = GetValueFor(date);
            
                // also be sure to lock ANYWHERE ELSE you're manipulating
                // or reading from the collection
                Values[date] = new PrecalculateValue{date = date, value = value};
                return value;
            }
        }
        private object GetValueFor(DateTime date)
        {
            //some logic here
        }
    }
