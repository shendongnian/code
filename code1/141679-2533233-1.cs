    public static class ItemExtensions 
    {
      public static string Name(this Item item)
      {
        return item.Data["lastname"];
      }
    }
    //Call by: i.Name().StartsWith("abc");
