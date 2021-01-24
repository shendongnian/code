    List<string> toRemove = new List<string>();  
    foreach(KeyValuePair pair in myDict.Reverse())
    {
         if(pair.key.StartsWith("MyKey_"))
         {
               toRemove.Add(pair.key);
               toRemoveCount--;
         }
         if(toRemove.Count == 2)
         {
               break;
         }
    }
    foreach(string str in toRemove)
    {
          myDict.Remove(str);
    }
