    for(int i = originalList.length-1; i >=0; --i)
    {
         if (!newList.Contains(originalList[i])
                originalList.RemoveAt(i);
    }
    
    foreach(int n in newList)
    {
         if (!originaList.Contains(n))
               originalList.Add(n);
    }
