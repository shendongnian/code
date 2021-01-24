    public static class MyExtensions
    {
    	 public static IEnumerable<string> OrderByCyrillicFirst(this IEnumerable<string> list)
         {
             var cyrillicOrderedList = list.Where(l => string.IsNullOrEmpty(l) ? false : IsCyrillic(l[0])).OrderBy(l => l);
             var latinOrderedList = list.Where(l => string.IsNullOrEmpty(l) ? true : !IsCyrillic(l[0])).OrderBy(l => l);
             return cyrillicOrderedList.Concat(latinOrderedList);
         }
    
         public static IEnumerable<string> OrderByCyrillicFirstDescending(this IEnumerable<string> list)
         {
             var cyrillicOrderedList = list.Where(l => string.IsNullOrEmpty(l) ? false : IsCyrillic(l[0])).OrderByDescending(l => l);
             var latinOrderedList = list.Where(l => string.IsNullOrEmpty(l) ? true : !IsCyrillic(l[0])).OrderByDescending(l => l);
             return cyrillicOrderedList.Concat(latinOrderedList);
         }
    
        //cyrillic symbols start with code 1024 and end with 1273.
    	private static bool IsCyrillic(char ch) =>
    		ch >= 1024 && ch <= 1273;    	
    }
