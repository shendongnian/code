    public static class SplitExtensions {
        public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> src, T separator) {
            var group = new List<T>();
            foreach (var elem in src){
                if (Equals(elem, separator)){
                    yield return group;
                    group = new List<T>();
                } else{
                    group.Add(elem);
                }
            }
            yield return group;
        }
    }
