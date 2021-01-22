    Dictionaty<string, int> listCount = new Dictionaty<string, int>();
    for (int i = 0; i < yourList.Count; i++)
    {
     if(listCount.ContainsKey(yourList[i]))
      listCount[yourList[i].Trim()] = listCount[yourList[i].Trim()] + 1;
     else
      listCount[yourList[i].Trim()] = 1;
    }
