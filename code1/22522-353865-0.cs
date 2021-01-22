      public static void AppendCollection<TItem>(this StringBuilder builder, IEnumerable<TItem> items, Func<TItem, string> valueSelector)
      {
           foreach(TItem item in items)
           {  
                builder.Append(valueSelector(item));
           }
      }
