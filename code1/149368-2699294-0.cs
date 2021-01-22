    var myDictionary = new SortedList<decimal, string>();
    
    // omitted code
    
    int i = 0;
    while (myDictionary.Count > 0 && i < myDictionary.Count)
    {
      if (/* predicate to use for removal */)
      {
        myDictionary.RemoveAt(i);
      }
      else
      {
        i++;
      }
    }
