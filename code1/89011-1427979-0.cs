    public class Product
    {
        public void AmountInInventory(int warehouseId, bool includeReturns)
        {
            int totalCount = CountOfNewItems();
            if (includeReturns)
                totalCount+= CountOfReturnedItems();
            return totalCount;
        }
    }
