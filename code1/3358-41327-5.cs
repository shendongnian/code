    static void Main (string [] args)
    {
      Random
        random = new Random();
      List<List<int>>
        items = new List<List<int>>();
      for (int i = 0 ; i < 10 ; ++i)
      {
        List<int>
          list = new List<int> ();
        
        items.Add (list);
        for (int j = 0 ; j < 100 ; ++j)
        {
          list.Add (random.Next (70));
        }
      }
      SortedDictionary<int, bool>.KeyCollection
        common = FindCommon (items);
      foreach (List<int> list in items)
      {
        list.Sort ();
      }
      for (int i = 0 ; i < 100 ; ++i)
      {
        for (int j = 0 ; j < 10 ; ++j)
        {
          System.Diagnostics.Trace.Write (String.Format ("{0,-4:D} ", items [j] [i]));
        }
        System.Diagnostics.Trace.WriteLine ("");
      }
      foreach (int item in common)
      {
        System.Diagnostics.Trace.WriteLine (String.Format ("{0,-4:D} ", item));
      }
    }
