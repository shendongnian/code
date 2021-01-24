    public static class ExtensionMethods
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> src, Func<T, bool> testFn, T defval)
        {
            return src.Where(aT => testFn(aT)).DefaultIfEmpty(defval).First();
        }
        public static int IndexOf(this string source, string match, IEqualityComparer<string> sc)
        {
            return Enumerable.Range(0, source.Length) // for each position in the string
                             .FirstOrDefault(i => // find the first position where either
                                                  // match is Equals at this position for length of match (or to end of string) or
                                 sc.Equals(source.Substring(i, Math.Min(match.Length, source.Length - i)), match) ||
                                 // match is Equals to on of the substrings beginning at this position
                                 Enumerable.Range(1, source.Length - i - 1).Any(ml => sc.Equals(source.Substring(i, ml), match)),
                                 -1 // else return -1 if no position matches
                              );
        }
    }
    public class CaseAccentInsensitiveEqualityComparer : IEqualityComparer<string>
    {
        private static readonly CompareOptions _compareoptions = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth | CompareOptions.IgnoreSymbols;
        private static readonly CultureInfo _cultureinfo = CultureInfo.InvariantCulture;
        public bool Equals(string x, string y)
        {
            return string.Compare(x, y, _cultureinfo, _compareoptions) == 0;
        }
        public int GetHashCode(string obj)
        {
            return obj != null ? RemoveDiacritics(obj).ToUpperInvariant().GetHashCode() : 0;
        }
        private string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            ).Normalize(NormalizationForm.FormC);
        }
    }
    public class CitiesCollection
    {
        private SuffixDict<City> _suffixdict;
        private HashSet<string> _countries;
        private Dictionary<int, City> _cities;
        private readonly IEqualityComparer<string> _comparer = new CaseAccentInsensitiveEqualityComparer();
        public CitiesCollection(IEnumerable<City> cities, int minLen, int capacity = 1000)
        {
            _suffixdict = new SuffixDict<City>(minLen, _comparer, capacity);
            _countries = new HashSet<string>();
            _cities = new Dictionary<int, City>(capacity);
            foreach (var c in cities)
            {
                _suffixdict.Add(c.Name, c);
                _countries.Add(c.Country);
                _cities.Add(c.Id, c);
            }
        }
        public City this[int index] => _cities[index];
        public IEnumerable<string> Countries => _countries;
        public IEnumerable<City> Find(string find, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            foreach (var city in _suffixdict.Find(find).Where(v => v.Name.IndexOf(find, _comparer) >= 0))
                yield return city;
        }
    }
    public class SuffixDict<T>
    {
        private readonly int _suffixsize;
        private ConcurrentDictionary<string, IList<T>> _dict;
        public SuffixDict(int suffixSize, IEqualityComparer<string> stringComparer, int capacity = 1000)
        {
            _suffixsize = suffixSize;
            _dict = new ConcurrentDictionary<string, IList<T>>(Environment.ProcessorCount, capacity, stringComparer);
        }
        public void Add(string suffix, T value)
        {
            foreach (var s in GetSuffixes(suffix, _suffixsize))
                AddDict(s, value);
        }
        public IEnumerable<T> Find(string suffix)
        {
            var find = suffix.Substring(0, Math.Min(suffix.Length, _suffixsize));
            if (_dict.TryGetValue(find, out var result))
            {
                foreach (var i in result)
                    yield return i;
            }
        }
        private void AddDict(string suffix, T value)
        {
            _dict.AddOrUpdate(suffix, (s) => new List<T>() { value }, (k, v) => { v.Add(value); return v; });
        }
        private static IEnumerable<string> GetSuffixes(string value, int suffixSize)
        {
            if (value.Length < 2)
            {
                yield return value;
            }
            else
            {
                for (var i = 0; i <= value.Length - suffixSize; i++)
                    yield return value.Substring(i, suffixSize);
            }
        }
    }
