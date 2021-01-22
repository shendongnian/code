    public void PrintNames(List<string> names)
    {
      foreach(string name in names)
      {
        int index; // not initialized (#1)
        GetIndex(out index);
        Console.WriteLine(index.ToString() + ". " + name);
      }
    }
    public void GetIndex(out int index)
    {
      index = IndexHelper.GetLatestIndex(); // needs to be assigned a value (#2 & #3)
    }
