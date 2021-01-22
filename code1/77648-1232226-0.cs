    public class MyClassList
    {
        private List<int> _lst = new List<int>() { 1, 2, 3 };
        public IEnumerable<int> ListEnumerator
        {
            get { return _lst.AsReadOnly(); }
        }
        
    }
