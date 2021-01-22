    public IEnumerable<string> DivideEmailList(string list) {
      var last = 0;
      var cur = list.IndexOf(';');
      while ( cur >= 0 ) {
        yield return list.SubString(last, cur-last);
        last = cur + 1;
        cur = list.IndexOf(';', last);
      }
    }
    
    public IEnumerable<List<string>> ChunkEmails(string list) {
      using ( var e = DivideEmailList(list).GetEnumerator() ) {
         var list = new List<string>();
         while ( e.MoveNext() ) {
           list.Add(e.Current);
           if ( list.Count == 50 ) {
             yield return list;
             list = new List<string>();
           }
         }
         if ( list.Count != 0 ) {
           yield return list;
         }
      }
    }
