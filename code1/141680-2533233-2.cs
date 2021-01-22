    public static string NameStartsWith(this Item item, stirng start)
    {
      return item.Data["lastname"].StartsWith(start);
    }
    //Call by: i.NameStartsWith("abc");
