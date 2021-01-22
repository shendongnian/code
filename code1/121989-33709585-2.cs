     public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source) {
         if (source == null) {
            return true;
         }
         return !source.Any();
     }
     public static bool IsNotNullOrEmpty<TSource>(this IEnumerable<TSource> source) {
         return !source.IsNullOrEmpty();
     }
     .
     .
     .
     if (!sequence.IsNullOrEmpty()) {
         //Do Something with the sequence...
     }
