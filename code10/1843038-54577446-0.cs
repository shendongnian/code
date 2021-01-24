    static class EnumerableExtensions
    {
        public static IEnumerable<Item> Combine(this IEnumerable<Item> items)
        {
            using (var enumerator = items.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    yield break;
                var previous = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    var next = enumerator.Current;
    
                    if (TryCombine(previous, next, out var updatedPrevious))
                    {
                        previous = updatedPrevious;
                        continue;
                    }
    
                    yield return previous;
                    previous = next;
                }
                yield return previous;
            }
        }
    }
