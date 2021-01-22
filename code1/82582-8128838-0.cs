    public void PrintNames(List<string> names)
    {
      int index = 0; // 1. initialize first
      foreach(string name in names)
      {
        IncrementIndex(ref index);
        Console.WriteLine(index.ToString() + ". " + name);
      }
    }
    public void IncrementIndex(ref int index)
    {
      index++; // 2. initial value was passed in
    }
out
