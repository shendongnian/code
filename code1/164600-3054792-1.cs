    foreach (var item in ForEachHelper.Wrap(collection))
    {
      if (item.IsFirst)
      {
        Console.WriteLine("first");
      }
      Console.WriteLine(item.Value.ToString() + " at position " + item.Index.ToString());
      if (item.IsLast)
      {
        Console.WriteLine("last");
      }
    }
