    public class DVDCollection
    {
        private Dictionary<string, DVD> store = null;
        private Dictionary<ProductId, string> dvdsByProductId = null;
    
        public DVDCollection()
        {
            // gets DVD data from somewhere and stores it *by* TITLE in "store"
            // stores a lookup set of DVD ProductId's and names in "dvdsByProductid"
            store = new Dictionary<string, DVD>();
            dvdsByProductId = new Dictionary<ProductId, string>();
        }
    
        // Get the DVD concerned, using an index, by product Id
        public DVD this[ProductId index]  
        {
           var title = dvdsByProductId[index];
           return store[title];
        }
    }
