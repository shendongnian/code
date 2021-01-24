    namespace System.Collections.Immutable {
      public static class ExtensionMethods {
        public static ImmutableHashSet<T> RemoveWhere<T>(this ImmutableHashSet<T> hashSet, Predicate<T> match) => 
          hashSet.RemoveWhere(match, out _);
    
        public static ImmutableHashSet<T> RemoveWhere<T>(this ImmutableHashSet<T> hashSet, Predicate<T> match, out int numRemoved) {
          if (match == null) throw new ArgumentNullException(nameof(match));
          var hashSetBuilder = hashSet.ToBuilder();
          numRemoved = 0;
          foreach (var value in hashSet) if (match(value) && hashSetBuilder.Remove(value)) numRemoved++;
          return hashSetBuilder.ToImmutable();
        }
      }
    }
 
