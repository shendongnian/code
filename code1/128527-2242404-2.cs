    static class IEnumerableExtensions {
        public static IEnumerable<T> TakeUntil<T>(
            this IEnumerable<T> elements,
            Func<T, bool> predicate
        ) {
            return elements.Select((x, i) => new { Item = x, Index = i })
                           .TakeUntil((x, i) => predicate(x.Item))
                           .Select(x => x.Item);
        }
        public static IEnumerable<T> TakeUntil<T>(
            this IEnumerable<T> elements,
            Func<T, int, bool> predicate
        ) {
            int i = 0;
            foreach (T element in elements) {
                if (predicate(element, i)) {
                    yield return element;
                    yield break;
                }
                yield return element;
                i++;
            }
        }
    }
