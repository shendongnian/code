    public static class MyExtensions
    {
        public static string Elem(this string[] x, int depth = 0) 
           => x.Length <= depth ? null : x[depth];
        
        public static IOrderedEnumerable<string[]> CustomThenBy(this IOrderedEnumerable<string[]> list, int depth = 0) 
           => list.ThenBy(x => x.Elem(depth))
                  .ThenBy(x => x.Length);
        
        public static IOrderedEnumerable<string[]> CustomOrderBy(this IEnumerable<string[]> list,int depth =0)  
           => list.OrderBy(x => x.Elem(depth))
                  .ThenBy(x => x.Length);
       
       public static List<string>  NamespaceOrderBy(this List<string> list)
       {
          var split = list.Select(x => x.Split('.')).ToList();
          var maxDepth = split.Max(x => x.Length);
    
          var result = split.CustomOrderBy();
    
          for (var depth = 0; depth < maxDepth; depth++)        
             result = result.CustomThenBy(depth); 
          
          return result.Select(x => string.Join(".", x)).ToList();
       }
    }
