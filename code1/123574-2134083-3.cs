    class BaseCollection<TRecord> : BaseCollection, IEnumerable<TRecord> 
                                        where TRecord :  BaseRecord,new()
    {
        public IEnumerator<TRecord> GetEnumerator()
        {
            return Items.Cast<TRecord>().GetEnumerator(); 
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
