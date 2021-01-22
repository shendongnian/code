    public class TwoDimensionalDictionary
    {
      private Dictionary<string, string> Items = new Dictionary<string, string>();
    
      public string this[string i1, string i2]
      {
        get
        {
          // insert null checks here
          return Items[BuildKey(i1, i2)];
        }
        set
        {
          Items[BuildKey(i1, i2)] = value;
        }
      }
      public string BuildKey(string i1, string i2)
      {
        return "I1: " + i1 + " I2: " + i2;
      }  
    }
