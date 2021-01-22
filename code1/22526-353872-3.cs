       public static StringBuilder AppendCollection<TItem>(
                      this StringBuilder builder, 
                      IEnumerable<TItem> items)
      {
          return AppendCollection(builder, items, x=>x.ToString());
       }
