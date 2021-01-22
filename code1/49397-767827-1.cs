        var indexs = "Prashant".MultipleIndex('a');
        
    //Extension Method's Class
        public static class Extensions
        {
             static int i = 0;
        
             public static int[] MultipleIndex(this string StringValue, char chChar)
             {
        
               var indexs = from rgChar in StringValue
                            where rgChar == chChar && i != StringValue.IndexOf(rgChar, i + 1)
                            select new { Index = StringValue.IndexOf(rgChar, i + 1), Increament = (i = i + StringValue.IndexOf(rgChar)) };
                i = 0;
                return indexs.Select(p => p.Index).ToArray<int>();
              }
        }
