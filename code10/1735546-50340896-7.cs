    public static class IEnumerableExt {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source) => new HashSet<T>(source);
        public static IEnumerable<T> Leave<T>(this ICollection<T> src, int drop) => src.Take(src.Count - drop);
        public static IEnumerable<T> Drop<T>(this ICollection<T> src, int drop) => (drop < 0) ? src.Leave(-drop) : src.Skip(drop);
        public static T MinBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> keySelector, Comparer<TKey> keyComparer) => src.Aggregate((a, b) => keyComparer.Compare(keySelector(a), keySelector(b)) < 0 ? a : b);
        public static T MinBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> keySelector) => src.Aggregate((a, b) => Comparer<TKey>.Default.Compare(keySelector(a), keySelector(b)) < 0 ? a : b);
    }
    
    public static class StringExt {
        public static string UpTo(this string s, Regex stopRE) {
            var m = stopRE.Match(s);
            if (m.Success)
                return s.Substring(0, m.Index);
            else
                return s;
        }
        public static string UpTo(this string s, Func<char, bool> testfn) {
            var m = s.Select((ch, Index) => new { ch, Index, Success = testfn(ch) }).FirstOrDefault(cit => cit.Success);
            if (m != null && m.Success)
                return s.Substring(0, m.Index);
            else
                return s;
        }
    
        public static string Join(this IEnumerable<string> strings, string sep) => String.Join(sep, strings.ToArray());
        public static bool EndsWithOneOf(this string s, params string[] endings) => endings.Any(e => s.EndsWith(e));
    
        public static IEnumerable<string> Split(this string s, params string[] seps) => s.Split(StringSplitOptions.None, seps);
    
        public static IEnumerable<string> Split(this string s, StringSplitOptions so, params string[] seps) {
            int pos = 0;
            do {
                var sepPos = seps.Select(sep => new { pos = s.IndexOf(sep, pos) < 0 ? s.Length : s.IndexOf(sep, pos), len = sep.Length }).MinBy(pl => pl.pos);
                if (sepPos.pos > pos || so == StringSplitOptions.None)
                    yield return s.Substring(pos, sepPos.pos - pos);
                pos = sepPos.pos + sepPos.len;
            } while (pos <= s.Length);
        }
        public static string FirstWord(this string phrase) => phrase.UpTo(ch => Char.IsWhiteSpace(ch));
    
        public static bool IsAllLetters(this string s) => s.All(ch => Char.IsLetter(ch)); // faster than Regex
    }
    
    public static class DictionaryExt {
        public static TV GetValueOrDefault<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV defaultValue) => dict.TryGetValue(key, out TV value) ? value : defaultValue;
    }
