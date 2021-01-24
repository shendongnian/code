    public sealed class TupleExtraction<T, U> : IReadOnlyList<T>
    {
        readonly List<Tuple<T, U>> _list;
        public TupleExtraction(List<Tuple<T, U>> list)
        {
            _list = list;
        }
        public T this[int index] => _list[index].Item1;
        public int Count => _list.Count;
        public IEnumerator<T> GetEnumerator()
        {
            return _list.Select(item => item.Item1).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.Select(item => item.Item1).GetEnumerator();
        }
    }
