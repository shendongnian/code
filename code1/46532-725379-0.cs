    public class Foo
    {
        private readonly IList<Bar> _bars = new List<Bar>(); // Note IList<> vs List<>.
    
        public IList<Bar> Bars
        {
            get { return _bars; }
        }
    }
