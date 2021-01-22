    public class MyClassList
    {
        private List<int> li = new List<int> { 1, 2, 3 };
        public IEnumerable<int> MyList
        {
            get { return li; }
        }
    }
