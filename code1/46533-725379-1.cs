    public class Foo
    {
        private readonly IList<Bar> _bars = new List<Bar>();
    
        public IList<Bar> Bars
        {
            get { return _bars; }
        }
    }
