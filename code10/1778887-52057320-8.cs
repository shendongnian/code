    public class CitiesCollection
    {
        private SuffixDict<City> _suffixdict;
        public CitiesCollection(IEnumerable<City> cities, int minLen)
        {
            _suffixdict = new SuffixDict<City>(minLen);
            foreach (var c in cities)
                _suffixdict.Add(c.Name, c);
        }
        public IEnumerable<City> Find(string find, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            var normalizedFind = _suffixdict.NormalizeString(find);
            foreach (var city in _suffixdict.GetDistinct(normalizedFind).Where(v => v.Name.IndexOf(normalizedFind, stringComparison) >= 0))
                yield return city;
        }
    }
    public class SuffixDict<T>
    {
        private readonly int _suffixsize;
        private ConcurrentDictionary<string, IList<T>> _dict;
        public int Count => _dict.Count;
        public SuffixDict(int suffixSize)
        {
            _suffixsize = suffixSize;
            _dict = new ConcurrentDictionary<string, IList<T>>();
        }
        public void Add(string suffix, T value)
        {
            foreach (var s in GetSuffixes(suffix))
                AddDict(s, value);
        }
        public IEnumerable<T> GetDistinct(string suffix)
        {
            return Get(suffix).Distinct();
        }
        private IEnumerable<T> Get(string suffix)
        {
            foreach (var s in GetSuffixes(suffix))
            {
                if (_dict.TryGetValue(s, out var result))
                    foreach (var i in result)
                        yield return i;
            }
        }
        public string NormalizeString(string value)
        {
            return value.Normalize().ToLowerInvariant();
        }
        private void AddDict(string suffix, T value)
        {
            _dict.AddOrUpdate(suffix, (s) => new List<T>() { value }, (k, v) => { v.Add(value); return v; });
        }
        private IEnumerable<string> GetSuffixes(string value)
        {
            var nv = NormalizeString(value);
            if (nv.Length >= _suffixsize)
                for (var i = 0; i < nv.Length - _suffixsize; i++)
                    yield return nv.Substring(i, _suffixsize);
        }
    }
