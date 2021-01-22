    public class Xyz
    {
        private volatile int _lastValue;
        private IList<int> AvailableValues { get; set; }
        private object syncRoot = new object();
        private Random rand = new Random();
        //Accessible by multiple threads
        public int GetNextValue() //and return last value once store is exhausted
        {
            //...
            var returnValue;
            lock (syncRoot)
            {
                var count = AvailableValues.Count;
                if(count == 0)
                    return _lastValue;
                var toReturn = rand.Next(0, count);
                var returnValue = AvailableValues[toReturn];
                AvailableValues.RemoveAt(toReturn);
            }
            _lastValue = returnValue;
            return _lastValue;
        }
    }
