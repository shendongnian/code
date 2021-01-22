        public static IEnumerable<T> NoLast<T> (this IEnumerable<T> items) {
            if (items != null) {
                var e = items.GetEnumerator();
                if (e.MoveNext ()) {
                    T head = e.Current;
                    while (e.MoveNext ()) {
                        yield return head; ;
                        head = e.Current;
                    }
                }
            }
        }
