    public class Container
    {
        private readonly  List<int> _myList;
        public List<int> MyList
        {
            get { return _myList;}
        }
        public Container() : base ()
        {
            _myList = new List<int>();
        }
        public void BreakReadOnly()
        {
            _myList = new List<int>();
        }
    }
