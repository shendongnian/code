    public void PrintNames(List<string> names)
    {
      int index = 0; // initialize first (#1)
      foreach(string name in names)
      {
        IncrementIndex(ref index);
        Console.WriteLine(index.ToString() + ". " + name);
      }
    }
    public void IncrementIndex(ref int index)
    {
      index++; // initial value was passed in (#2)
    }
