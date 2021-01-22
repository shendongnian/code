        public static IEnumerable<T> Intersect<T>(IEnumerable<IEnumerable<T>> enums) {
            using (var iter = enums.GetEnumerator()) {
                IEnumerable<T> result;
                if (iter.MoveNext()) {
                    result = iter.Current;
                    while (iter.MoveNext()) {
                        result = result.Intersect(iter.Current);
                    }
                } else {
                    result = Enumerable.Empty<T>();
                }
                return result;
            }
        }
