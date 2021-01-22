    public class MultiValueDictionary<TKey, TValue> : 
        Dictionary<TKey, List<TValue>>
    {
        public void Add(TKey key, TValue value)
        {
            List<TValue> valList;
            //a single TryGetValue is quicker than Contains then []
            if (this.TryGetValue(key, out valList))
                valList.Add(value);
            else
                this.Add( key, new List<TValue> { value } );
        }
        //this can be simplified using yield 
        public IEnumerable<TValue> GetAllValues()
        {
            //dictionaries are already IEnumerable, you don't need the extra lookup
            foreach (var keyValPair in this)
                foreach(var val in keyValPair.Value);
                    yield return val;
        }
    }
