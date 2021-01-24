    public class CitiesCollection
    {
        private Dictionary<int, City> _cities;
        private SuffixDict<int> _suffixdict;
        public CitiesCollection(IEnumerable<City> cities, int minLen)
        {
            _cities = cities.ToDictionary(c => c.Id);
            _suffixdict = new SuffixDict<int>(minLen, _cities.Values.Count);
            foreach (var c in _cities.Values)
                _suffixdict.Add(c.Name, c.Id);
        }
        public IEnumerable<City> Find(string find)
        {
            var normalizedFind = _suffixdict.NormalizeString(find);
            foreach (var id in _suffixdict.Get(normalizedFind).Where(v => _cities[v].Name.IndexOf(normalizedFind, StringComparison.OrdinalIgnoreCase) >= 0))
                yield return _cities[id];
        }
    }
    public class SuffixDict<T>
    {
        private readonly int _suffixsize;
        private ConcurrentDictionary<string, IList<T>> _dict;
        public SuffixDict(int suffixSize, int capacity)
        {
            _suffixsize = suffixSize;
            _dict = new ConcurrentDictionary<string, IList<T>>(Environment.ProcessorCount, capacity);
        }
        public void Add(string suffix, T value)
        {
            foreach (var s in GetSuffixes(suffix))
                AddDict(s, value);
        }
        public IEnumerable<T> Get(string suffix)
        {
            return Find(suffix).Distinct();
        }
        private IEnumerable<T> Find(string suffix)
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
            for (var i = 0; i <= nv.Length - _suffixsize ; i++)
                yield return nv.Substring(i, _suffixsize);
        }
    }
