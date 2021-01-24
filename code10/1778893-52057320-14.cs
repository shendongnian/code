    public class CitiesCollection
    {
        private SuffixDict<City> _suffixdict;
        public CitiesCollection(IEnumerable<City> cities, int minLen, int capacity = 1000)
        {
            _suffixdict = new SuffixDict<City>(minLen, capacity);
            foreach (var c in cities)
                _suffixdict.Add(c.Name, c);
        }
        public IEnumerable<City> Find(string find, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            var normalizedFind = SuffixDict<City>.NormalizeString(find);
            var x = _suffixdict.GetDistinct(normalizedFind).ToArray();
            foreach (var city in _suffixdict.GetDistinct(normalizedFind).Where(v => v.Name.IndexOf(normalizedFind, stringComparison) >= 0))
                yield return city;
        }
    }
    public class SuffixDict<T>
    {
        private readonly int _suffixsize;
        private ConcurrentDictionary<string, IList<T>> _dict;
        public int Count => _dict.Count;
        public SuffixDict(int suffixSize, int capacity = 1000)
        {
            _suffixsize = suffixSize;
            _dict = new ConcurrentDictionary<string, IList<T>>(Environment.ProcessorCount, capacity);
        }
        public void Add(string suffix, T value)
        {
            foreach (var s in GetSuffixes(suffix, _suffixsize))
                AddDict(s, value);
        }
        public IEnumerable<T> GetDistinct(string suffix)
        {
            return Get(suffix).Distinct();
        }
        private IEnumerable<T> Get(string suffix)
        {
            foreach (var s in GetSuffixes(suffix, _suffixsize))
            {
                if (_dict.TryGetValue(s, out var result))
                    foreach (var i in result)
                        yield return i;
            }
        }
        private void AddDict(string suffix, T value)
        {
            _dict.AddOrUpdate(suffix, (s) => new List<T>() { value }, (k, v) => { v.Add(value); return v; });
        }
        public static string NormalizeString(string value)
        {
            return value.Normalize().ToLowerInvariant();
        }
        private static IEnumerable<string> GetSuffixes(string value, int suffixSize)
        {
            var nv = NormalizeString(value);
            for (var i = 0; i <= nv.Length - suffixSize; i++)
                yield return nv.Substring(i, suffixSize);
        }
    }
