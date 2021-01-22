    class DataItem
    {
      public String Name {get;set;}
      public String Address {get;set;}
      public String Comment {get;set;}
    
      public static DataItem operator=(DataItem item, String string)
      {
        item.Name = string.Substring(0, 10).Trim();
        item.Address = string.Substring(10, 25).Trim();
        item.Comment = string.Substring(25, 45).Trim();
        return item;
      }
    }
    [...]
    DataItem item = new DataItem();
    item = sampleString;
    [...]
