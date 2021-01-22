      public static class CollectionExtensions {
         public static ICollection<T> RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> predicate) {
            List<T> toRemove = collection.Where(item => predicate(item)).ToList();
            toRemove.ForEach(item => collection.Remove(item));
            return collection;
         }
      }
