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
            lock (syncRoot)
            {
                var count = AvailableValues.Count;
                if(count == 0)
                    return _lastValue;
                toReturn = rand.Next(0, count);
                _lastValue = AvailableValues[toReturn];
                AvailableValues.RemoveAt(toReturn);
            }
            return _lastValue;
        }
    }
