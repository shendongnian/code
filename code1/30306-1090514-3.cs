    public static class StringExtensions
      {
         public static IEnumerable CreateStringWrapperForBinding(this IEnumerable<string> strings)
         {
         var values = from data in strings
         select new { Value = data };
         
         return values.ToList();
         }
