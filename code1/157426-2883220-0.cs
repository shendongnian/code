    public class HrefCollection : IEnumerable<Href>
    {
        private readonly List<Href> _hrefs = new List<Href>();
        public void Add(Href href)
        {
            _hrefs.Add(href);
        }
        public void AddRange(IEnumerable<Href> hrefs)
        {
            _hrefs.AddRange(hrefs);
        }
        public IEnumerator<Href> GetEnumerator()
        {
            return _hrefs.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_hrefs).GetEnumerator();
        }
    }
