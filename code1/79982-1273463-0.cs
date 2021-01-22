    public static class Order
    {
       public const string Unknown = "Unknown";
       public const string Partial01 = "Partial01";
       public const string Partial12 = "Partial12";
       public const string Partial23 = "Partial23";
    }
    
    string value = Order.Partial01
    switch (value)
    {
       case Order.Partial01:
          break;
    
        default:
           // Code you might want to run in case you are
           // given a value that doesn't match.
           break;
    }
