    int indexOfLastMonthName = monthNames.IndexOf(lastMonthName);
    List<Tuple<int, string>> parentList = new List<Tuple<int, string>>();
    
    for(int i = 0; i < lastMonthNumber; lastMonthNumber++)
    {
      parentList.Add(
        Tuple.Create(
          12 - i, 
          GetMonthName(indexOfLastMonthName - i));
    }
    
    parentList.Reverse();
