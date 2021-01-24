    public Store(Dictionary<int, int> initialItems = null)
    {
       if (initialItems!=null)
          items = new Dictionary<int, int>(initialItems);
       else
          items = new Dictionary<int, int>();
       for (int i = 0; i < 45; i++) // 45 items should exist
       {                
         if (!items.ContainsKey(i))
             items.Add(i, 0); // initialize value with 0
       }
    }
    private Dictionary<int, int> items;
