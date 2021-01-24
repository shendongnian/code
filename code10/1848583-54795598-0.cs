    public static Dictionary<long, Category> IndexBuilder(Category c)
    {
      var index = new Dictionary<long, Category>();
      IndexBuilder(c, index);
      return index;
    }
    private static void IndexBuilder(Category c, Dictionary<long, Category> index)
    {
      if (index.ContainsKey(c.Id))
        return;
      index[c.Id] = c;
      foreach(var child in c.ChildrenData)
        IndexBuilder(child, index);
    }
