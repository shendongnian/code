    public class Xyz
    {
        private volatile int _lastValue;
        private IList<int> AvailableValues { get; set; }
        private object syncRoot = new object();
        //Accessible by multiple threads
        public int GetNextValue() //and return last value once store is exhausted
        {
            //...
            lock (syncRoot)
            {
                var toReturn = new Random().Next(0, AvailableValues.Count);
                if(AvailableValues.Count == 0)
                    return _lastValue;
                var returnValue = AvailableValues[toReturn];
                AvailableValues.RemoveAt(toReturn);
                _lastValue = returnValue;
            }
            return returnValue;
        }
