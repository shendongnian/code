    public class Histogram<TVal> : SortedDictionary<TVal, uint>
    {
        public void IncrementCount(TVal binToIncrement)
        {
            if (ContainsKey(binToIncrement))
            {
                this[binToIncrement]++;
            }
            else
            {
                Add(binToIncrement, 1);
            }
        }
    }
