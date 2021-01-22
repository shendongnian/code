     public IEnumerable<string> GetItems() {
         if (something) return null;
         return GetItemsInternal();
     }
     private IEnumerable<string> GetItemsInternal() {
         // the actual iterator with "yield return" goes here.
     }
