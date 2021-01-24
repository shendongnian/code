    class Item {
    
      public Int32 ItemId { get; set; }
    
      public String Name { get; set; }
    
      public IEnumerable<Item> Children { get; set; }
    }
