      public decimal ItemPrice 
      { 
        get { return Property.Get(0m); }
        set { Property.Set(value); }
      }
    
      public int Quantity 
      { 
        get { return Property.Get(0); }
        set { Property.Set(value); }
      }
    
      public decimal TotalPrice
      {
        get { return Property.Calculated(() => ItemPrice * Quantity); }    
      }
