    foreach (string key in sourceList.Keys)
    {
      Console.WriteLine(key);
      foreach(string value in sourceList[key])
      {
        Console.WriteLine("\t{0}", value);  // tab in answers one level
      }
      Console.WriteLine(); // separator between each set of q-n-a
    }
