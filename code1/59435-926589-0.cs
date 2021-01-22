    public class Histogram<TVal> : SortedDictionary<TVal, uint>
    {
        public void IncrementCount(TVal binToIncrement)
        {
            try
            {
                this[binToIncrement]++;
            }
            catch( KeyNotFoundException )
            {
                Add(binToIncrement, 1);
            }
        }
    }
