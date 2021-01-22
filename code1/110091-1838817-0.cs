    public class ListFacade<TIn, TOut> : IList<TOut> where TIn : TOut
    {
        private readonly IList<TIn> innerList;
        public ListFacade(IList<TIn> innerList)
        {
            this.innerList = innerList;
        }
        public int Count
        {
            get { return this.innerList.Count; }
        }
        public bool IsReadOnly
        {
            get { return this.innerList.IsReadOnly; }
        }
        public TOut this[int index]
        {
            get { return this.innerList[index]; }
            set { this.innerList[index] = (TIn)value; }
        }
        public void Add(TOut item)
        {
            this.innerList.Add((TIn)item);
        }
        public void Clear()
        {
            this.innerList.Clear();
        }
        public bool Contains(TOut item)
        {
            return (item is TIn) && this.innerList.Contains((TIn)item);
        }
        public void CopyTo(TOut[] array, int arrayIndex)
        {
            var inArray = new TIn[this.innerList.Count];
            this.innerList.CopyTo(inArray, arrayIndex);
            Array.Copy(inArray, array, inArray.Length);
        }
        public IEnumerator<TOut> GetEnumerator()
        {
            foreach (var item in this.innerList)
            {
                yield return item;
            }
        }
        System.Collections.IEnumerator
            System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public int IndexOf(TOut item)
        {
            return (item is TIn) ? this.innerList.IndexOf((TIn)item) : -1;
        }
        public void Insert(int index, TOut item)
        {
            this.innerList.Insert(index, (TIn)item);
        }
        public bool Remove(TOut item)
        {
            return (item is TIn) && this.innerList.Remove((TIn)item);
        }
        public void RemoveAt(int index)
        {
            this.innerList.RemoveAt(index);
        }
