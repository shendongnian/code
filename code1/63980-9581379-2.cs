    // One of the problems with Enumerable.Count() is
    // that it is a 'terminator', meaning that it will
    // execute the expression it is given, and discard
    // the resulting sequence. To count the number of
    // items in a sequence without discarding it, we 
    // can use this variant that takes an Action<int>
    // (or Action<long>), invokes it and passes it the
    // number of items that were yielded.
    //
    // Example: This example allows us to find out
    //          how many items were in the original
    //          source sequence 'items', as well as
    //          the number of items consumed by the
    //          call to Sum(), without causing any 
    //          LINQ expressions involved to execute
    //          multiple times.
    // 
    //   int start = 0;    // the number of items from the original source
    //   int finished = 0; // the number of items in the resulting sequence
    //
    //   IEnumerable<KeyValuePair<string, double>> items = // assumed to be an iterator
    //
    //   var result = items.Count( i => start = i )
    //                   .Where( p => p.Key = "Banana" )
    //                      .Select( p => p.Value )
    //                         .Count( i => finished = i )
    //                            .Sum();
    //
    //   // by getting the count of items operated 
    //   // on by Sum(), we can calculate an average:
    // 
    //   double average = result / (double) finished; 
    //
    //   Console.WriteLine( "started with {0} items", start );
    //   Console.WriteLine( "finished with {0} items", finished );
    //
    
    public static IEnumerable<T> Count<T>( 
        this IEnumerable<T> source, 
        Action<int> receiver )
    {
      int i = 0;
      foreach( T item in source )
      {
        yield return item;
        ++i ;
      }
      receiver( i );
    }
    public static IEnumerable<T> Count<T>( 
        this IEnumerable<T> source, 
        Action<long> receiver )
    {
      long i = 0;
      foreach( T item in source )
      {
        yield return item;
        ++i ;
      }
      receiver( i );
    }
