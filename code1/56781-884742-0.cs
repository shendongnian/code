    public static IEnumerable<T> GetRange<T>(IEnumerable<T> source, int start, int end ) {
      using ( var e = source.GetEnumerator() ){ 
        var i = 0;
        while ( i < start && e.MoveNext() ) { i++; }
        while ( i < end && e.MoveNext() ) { 
          yield return e.Current;
          i++;
        }
      }      
    }
    IEnumerable<Foo> col = GetTheCollection();
    IEnumerable<Foo> range = GetRange(col, 250, 340);
