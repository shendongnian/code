    public class CovariantReadOlyList<TSource, TDest> : IList<TDest>, IReadOnlyList<TDest> where TSource : class, TDest
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
            // Using the nuget package System.Runtime.CompilerServices.Unsafe
            // source.CopyTo(Unsafe.As<TSource[]>(array), arrayIndex);
            // We love to play with fire :-)
            foreach (TSource ele in source)
            {
                array[arrayIndex] = ele;
                arrayIndex++;
            }
        }
        public IEnumerator<TDest> GetEnumerator() => ((IEnumerable<TDest>)source).GetEnumerator();
        public int IndexOf(TDest item)
        {
            TSource item2 = item as TSource;
            if (ReferenceEquals(item2, null) && !ReferenceEquals(item, null))
            {
                return -1;
            }
            return source.IndexOf(item2);
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
