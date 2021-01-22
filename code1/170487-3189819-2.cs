    public IEnumerator<T> GetEnumerator() { return new myTypeEnumerator<T>(this); }
    public class myTypeEnumerator<T> : IEnumerator<T>
    {
        int nIndex;
        IList<T> tList;
        public myTypeEnumerator(IList<T> listOfTs) 
         { 
            tList = listOfTs; 
            nIndex = -1; 
         }
        public bool MoveNext() { return (++nIndex < tList.Count); }
        public T Current { get { return (tList[nIndex]); } }
        public void Reset() { nIndex = -1; }
    }
