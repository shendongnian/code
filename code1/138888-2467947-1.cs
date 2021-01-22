    class DataBucket {
      private Dictionary<string,int> _priceMap = new Dictionary<string,int>();
      public DataBucket() {
        _priceMap["Acme.ProductA.MinimumPrice"] = 50;
        _priceMap["Acme.ProductB.MinimumPrice"] = 60;
      }   
      public int GetValue(string key) { 
        int price = 0;
        if ( !_priceMap.TryGetValue(key, out price)) {
          price = 100;
        }
        return price;
      }
    }
