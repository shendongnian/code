    public class Thing
    {
      public IValueFetcher ValueFetcher { get; set; }
    
      public int Number 
      { 
        get 
        {
          return this.ValueFetcher.GetValue<int>(/* parameters to identify the value to fetch */);
        }
      }
    }
