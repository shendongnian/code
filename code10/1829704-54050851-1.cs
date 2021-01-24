    foreach(KeyValuePair<int, Item> entry in itemDict)
    {
        	
      switch(entry.Value)
      {
        case Tool tool:
          Console.WriteLine(tool.toolDurability);
          break;
        case Item item:
          Console.WriteLine(item.itemID);
          break;
       }
     }
