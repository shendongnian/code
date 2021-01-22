    public static ArrayList ToArrayList(this IEnumerable enumerable) {  
      var list = new ArrayList;
      for ( var cur in enumerable ) {
        list.Add(cur);
      }
      return list;
    }
    
    public static Stack ToStack(this IEnumerable enumerable) {
      return new Stack(enumerable.ToArrayList());
    }
    
    var list = "hello wolrld".Split(' ').ToArrayList();
