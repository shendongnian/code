    public class CovariantReadOlyList<TSource, TDest> : IList<TDest>, IReadOnlyList<TDest> where TSource : TDest
    {
        private readonly IList<TSource> source;
        public CovariantReadOlyList(IList<TSource> source)
        {
            this.source = source;
        }
        public TDest this[int index] { get => source[index]; set => throw new NotSupportedException(); }
        public int Count => source.Count;
        public bool IsReadOnly => true;
        public void Add(TDest item) => throw new NotSupportedException();
        public void Clear() => throw new NotSupportedException();
        public bool Contains(TDest item) => IndexOf(item) != -1;
        public void CopyTo(TDest[] array, int arrayIndex)
        {
            foreach (TSource ele in source)
            {
                array[arrayIndex] = ele;
                arrayIndex++;
            }
        }
        public IEnumerator<TDest> GetEnumerator() => ((IEnumerable<TDest>)source).GetEnumerator();
        public int IndexOf(TDest item)
        {
            int i = 0;
            foreach (TSource ele in source)
            {
                if (ReferenceEquals(item, ele))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public void Insert(int index, TDest item)
        {
            throw new NotSupportedException();
        }
        public bool Remove(TDest item)
        {
            throw new NotSupportedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
