    public class Foo
    {
        private List<Bar> _bars = new List<Bar>();
        public IEnumerable<Bar> Bars { get { return _bars.AsReadOnly(); } }
        public void AddBar(Bar bar) //black sheep
        {
            //Insert validation logic here
            _bars.Add(bar);
        }
    }
