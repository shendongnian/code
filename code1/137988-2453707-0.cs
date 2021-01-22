    public class PagedList<T> : IEnumerable<T>, ICollection
    {
        private IEnumerable<T> ActualPage { get; set; }
        private int Total { get; set; }
        private int StartIndex { get; set; }
        public PagedList(int total, int startIndex, IEnumerable<T> actualPage)
        {
            ActualPage = actualPage;
            Total = total;
            StartIndex = startIndex;
        }
        public IEnumerator<T> GetEnumerator()
        {
            bool passouPagina = false;
            for (int i = 0; i < Total; i++)
            {
                if (i < StartIndex || passouPagina)
                {
                    yield return default(T);
                }
                else
                {
                    passouPagina = true;
                    foreach (T itempagina in ActualPage)
                    {
                        i++;
                        yield return itempagina;
                    }
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #region Implementation of ICollection
        void ICollection.CopyTo(Array array, int index)
        {
            throw new NotSupportedException();
        }
        public int Count
        {
            get { return Total; }
        }
        object ICollection.SyncRoot
        {
            get { throw new NotSupportedException(); }
        }
        bool ICollection.IsSynchronized
        {
            get { throw new NotSupportedException(); }
        }
        #endregion
    }
