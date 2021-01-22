    struct Pair<T> { 
        public T First;
        public T Second;
    }
    static class LinqExtension {
        public static IEnumerable<Pair<T>> EachPair<T>(this IEnumerable<T> input) {
            T first = default(T);
            bool gotFirst = false;
            foreach (var item in input)
            {
                if (!gotFirst)
                {
                    first = item;
                    gotFirst = true;
                }
                else {
                    yield return new Pair<T>() { First = first, Second = item };
                    gotFirst = false;
                }
            } 
        }
    }
