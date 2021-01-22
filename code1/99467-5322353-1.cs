    public static class Extensions
    {
        public static IEnumerable<T> SkipIf<T>(this IEnumerable<T> items, Predicate<T> pred)
            {
                return pred(items.First()) ? items.Skip(1) : items;
            }
    }
    public class CustomSortAsc : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            var ignorePredicates = new List<string> { "a", "the" }; 
            var px = Convert
                        .ToString(x)
                        .Replace("{", "")
                        .Replace("}", "")
                        .Split(' ')
                        .SkipIf(s => ignorePredicates.Contains(s.ToLower()))
                        .ToArray();
            var py = Convert
                        .ToString(y)
                        .Replace("{", "")
                        .Replace("}", "")
                        .Split(' ')
                        .SkipIf(s => ignorePredicates.Contains(s.ToLower()))
                        .ToArray();
            var newX = string.Join("", px);
            var newY = string.Join("", py);
            return string.Compare(newX, newY, true);
        }
    }
