    public class Product
    {
        [Flags]public enum Include{None=0, New=1, Returns=2, All=3 }
        public void AmountInInventory(int warehouseId, Include include)
        {
            int totalCount = 0;
            if ((include & Include.New) == Include.New)
                totalCount += CountOfNewItems();
            if ((include & Include.Returns) == Include.Returns)
                totalCount += CountOfReturns();
            return totalCount;
        }
    }
      product P = new Product();
      int TotalInventory = P.AmountInInventory(123, Product.Include.All);  
