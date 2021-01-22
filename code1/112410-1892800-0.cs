    public class Wrapper : IEnumerable<int>
    {
        public List<int> TList
        {get;set;}
        public IEnumerator<int> GetEnumerator()
        {
            return TList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() // Explicitly implement the non-generic version.
        {
            return TList.GetEnumerator();
        }
        public void Add(int i)
        {
             TList.Add(i);
        }
        public Wrapper()
        {
            TList=new List<int>();
        }
    }
