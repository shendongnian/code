    public class Wrapper : IEnumerable<int>
    {
        public List<int> TList
        { get; private set; }
        public Wrapper()
        {
            TList = new List<int>();
        }
    
        public void Add(int item)
        {
            TList.Add(item);
        }
        public IEnumerator<int> GetEnumerator()
        {
            return TList.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
