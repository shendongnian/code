    abstract class BaseCollection<TRecord> : BaseCollection, IEnumerable<TRecord>, IQueryable<TRecord> where TRecord : BaseRecord, new()
    {
        public new IEnumerator<TRecord> GetEnumerator()
        {
            return Items.Cast<TRecord>().GetEnumerator();
        }
        #region IQueryable<TRecord> Implementation
        public Type ElementType
        {
            get { return typeof(TRecord); }
        }
        public System.Linq.Expressions.Expression Expression
        {
            get { return this.ToList<TRecord>().AsQueryable().Expression; }
        }
        public IQueryProvider Provider
        {
            get { return this.ToList<TRecord>().AsQueryable().Provider; }
        }
        #endregion
    }
