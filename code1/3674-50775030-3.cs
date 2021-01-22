    public static class CollectionExtensions {
        public static bool Represents<T>(this IEnumerable<T> first, IEnumerable<T> second) {
            if(object.ReferenceEquals(first, second)) {
                return true;
            }
            if(first is IOrderedEnumerable<T> && second is IOrderedEnumerable<T>) {
                return Enumerable.SequenceEqual(first, second);
            }
            if(first is ICollection<T> && second is ICollection<T>) {
                if(first.Count()!=second.Count()) {
                    return false;
                }
            }
            first=first.OrderBy(x => x.GetHashCode());
            second=second.OrderBy(x => x.GetHashCode());
            return CollectionExtensions.Represents(first, second);
        }
    }
