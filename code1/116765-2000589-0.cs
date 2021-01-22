    public class MyDictEnumerator<T> : IEnumerator<T>
    {
        private List<T> Dict;
        private static int curLocation = -1;
        public MyDictEnumerator(List<T> dictionary)
        {
            Dict = dictionary;
        }
        public T Current
        {
            get { return Dict[curLocation]; }
        }
        public void Dispose()
        { }
        object System.Collections.IEnumerator.Current
        {
            get { return Dict[curLocation]; }
        }
        public bool MoveNext()
        {
            curLocation++;
            if (curLocation >= Dict.Count)
                return false;
            return true;
        }
        public void Reset()
        {
            curLocation = -1;
        }
    }
