    public static IList<T> NextList<T>(this Random r, IEnumerable<T> source)
    {
      var list = new List<T>();
      foreach (var item in source)
      {
        var i = r.Next(list.Count + 1);
        if (i == list.Count)
        {
          list.Add(item);
        }
        else
        {
          var temp = list[i];
          list[i] = item;
          list.Add(temp);
        }
      }
      return list;
    }
