        static void Main() {
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 1, 2, 3, 4, 5 };
            foreach (var c in a.Merge(b, (x, y) => x + y)) {
                Console.WriteLine(c);
            }
        }
        static IEnumerable<T> Merge<T>(this IEnumerable<T> first,
                IEnumerable<T> second, Func<T, T, T> operation) {
            using (var iter1 = first.GetEnumerator())
            using (var iter2 = second.GetEnumerator()) {
                while (iter1.MoveNext()) {
                    if (iter2.MoveNext()) {
                        yield return operation(iter1.Current, iter2.Current);
                    } else {
                        yield return iter1.Current;
                    }
                }
                while (iter2.MoveNext()) {
                    yield return iter2.Current;
                }
            }
        }
