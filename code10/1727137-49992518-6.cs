    public static IOrderedEnumerable<string[]> RecusiveCustomOrderBy(this IOrderedEnumerable<string[]> list,int maxDepth, int depth = 1)
    {
       if (depth >= maxDepth)
          return list;
    
       return list.ThenBy(x => x.Length <= depth ? null : x[depth])
                  .ThenBy(x => x.Length)
                  .RecusiveCustomOrderBy(maxDepth, depth + 1);
    }
    
    public static List<string> NamespaceOrderBy(this List<string> list)
    {
       var split = list.Select(x => x.Split('.')).ToList();
       var maxDepth = split.Max(x => x.Length);
    
       return split.OrderBy(x => x[0])
                   .ThenBy(x => x.Length)
                   .RecusiveCustomOrderBy(maxDepth)
                   .Select(x => string.Join(".", x))
                   .ToList();
    }
