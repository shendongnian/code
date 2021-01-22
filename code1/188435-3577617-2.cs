    static void Main(string[] args)
    {
      string[] oldList = { "a", "b", "c", "d", "e" };
      string[] newList = { "d", "e", "f", "g" };      
      Array.Sort(oldList);
      Array.Sort(newList);
      int p1 = 0;
      int p2 = 0;
      while (p1 < oldList.Length && p2 < newList.Length)
      {
        if (string.Compare(oldList[p1], newList[p2]) == 0)
        {
          Console.WriteLine("Unchanged:\t{0}", oldList[p1]);
          p1++;
          p2++;
        }
        else if (string.Compare(oldList[p1], newList[p2]) < 0)
        {
          Console.WriteLine("Removed:\t{0}", oldList[p1]);
          p1++;
        }
        else if (string.Compare(oldList[p1], newList[p2]) > 0)
        {
          Console.WriteLine("Added:\t\t{0}", newList[p2]);
          p2++;
        }        
      }
      
      while (p1 < oldList.Length)
      {
        Console.WriteLine("Removed:\t{0}", oldList[p1]);
        p1++;
      }
      while (p2 < newList.Length)
      {
        Console.WriteLine("Added :\t\t{0}", newList[p2]);
        p2++;
      }
      Console.ReadKey();
    }
