    public class DVDCollection
    {
      private static Dictionary<string, DVD> store = new Dictionary<string, DVD>();
      private static Dictionary<ProductId, string> dvdsByProductId = new Dictionary<string, string>();
    
      public DVDCollection()
      {
       // ... gets DVD data from somewhere and stores it *by* TITLE in "store"
       // ... stores a lookup set of DVD ProductId's and names in "dvdsByProductid"
      }
    
      // Get the DVD concerned, using an index, by product Id
      public DVD this[ProductId index]  
      {
         string title = dvdsByProductId[index];
         return store[title];
      }
    }
