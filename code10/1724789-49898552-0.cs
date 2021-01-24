    /// <summary>
    /// Paged queryable
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public sealed class PagedQueryable<T> : IPagedEnumerable<T> ,IEnumerable<T>
    {
        IQueryable<T> _source = null;
        int? _totalCount = null;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="offset">start element</param>
        /// <param name="limit">max number of items to retrieve</param>
        public PagedQueryable(IQueryable<T> source, int offset, int? limit)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            _source = source;
            Limit = limit;
            Offset = Math.Max(offset, 0);
        }
        public int TotalCount
        {
            get
            {
                if (!_totalCount.HasValue && _source != null)
                    _totalCount = _source.Count();
                return _totalCount.GetValueOrDefault();
            }
        }
        public int? Limit { get; }
        public int Offset { get; }
        public IEnumerator<T> GetEnumerator()
        {
            if (_source is IOrderedQueryable<T>)
            {
                var query = _source.Skip(Offset);
                if (Limit.GetValueOrDefault() > 0)
                    query = query.Take(Limit.GetValueOrDefault());
                return query.ToList().GetEnumerator();
            }
            else
                return Enumerable.Empty<T>().GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
