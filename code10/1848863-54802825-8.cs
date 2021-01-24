    public static IEnumerable<List<T>> Buffer<T>(this IEnumerable<T> source, int chunk, Func<T, long> selector)
    {
       // safety first
       if (source == null) throw new ArgumentNullException(nameof(source));
    
       var list = new List<T>();
       long accum = 0;
    
       foreach (var item in source)
       {
          var size = selector(item);
    
          // sanity check
          if (size > chunk) throw new InvalidOperationException("Selector size cant be greater than chunk size");
    
          // Return chunk
          if ((accum += size) > chunk)
          {
             yield return list;
             list = new List<T>();
             accum = size;
          }
    
          list.Add(item); // always need to add the current
       }
    
       // Return any partial result
       if (list.Any()) yield return list;
    }
