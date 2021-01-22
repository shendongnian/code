    foreach (var item in ForEachHelper.Wrap(collection))
    {
      if (item.IsFirst)
      {
        Console.WriteLine("first");
      }
      Console.WriteLine("Position=" + item.Index.ToString());
      Console.WriteLine("Value=" + item.Value.ToString());
      if (item.IsLast)
      {
        Console.WriteLine("last");
      }
    }
