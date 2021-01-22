    interface IIndexedEnumerable<T> : IEnumerable<T>
    {
        //Not index, because sometimes source IEnumerables are transient
        public long IterationNumber { get; }
    }
