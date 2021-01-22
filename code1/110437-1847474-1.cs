     public static IList<T>[] Split<T>(
        this IList<T> source, // input IList to split
        int elementCount      // number of items per IList
    ) {
          return Split<T, T>(source, x => x, elementCount);      
    }
