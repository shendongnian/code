    static IEnumerable<T> Extract<T>(this ICollection<T> collection, IList<int> indexes)
    {
       int index = 0;
       foreach(var item in collection)
       {
         if (indexes.Contains(index))
           yield item;
         index++;
       }
    }
