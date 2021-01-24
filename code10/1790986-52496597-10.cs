    int indexOfLastMonthName = Array.IndexOf(monthNames, lastMonthName);
    List<Tuple<int, string>> parentList = new List<Tuple<int, string>>();
    
    for(int i = 0; i < lastMonthNumber; i++)
    {
      parentList.Add(
        Tuple.Create(
          12 - i, 
          GetMonthName(indexOfLastMonthName - i));
    }
    
    parentList.Reverse();
