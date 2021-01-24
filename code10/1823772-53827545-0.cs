    List<string> strList = new List<string>();
    List<int> intList = new List<int>();
    
    strList.Add("1");
    strList.Add("2");
    strList.Add("3");
    strList.Add("35tdfsfd");
    foreach (string el in strList)
    {
      int validInt;
      if (int.TryParse(el, out validInt))
      {
         intList.Add(validInt);
      }
    }
