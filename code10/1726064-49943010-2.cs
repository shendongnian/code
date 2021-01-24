    public sealed class ItemModel
    {
        public ItemModel(string itemName, decimal sellPrice, decimal buyPrice)
        {
            ItemName = itemName;
            SellPrice = sellPrice;
            BuyPrice = buyPrice;
        }
        
        public string ItemName { get; }
        public decimal SellPrice { get; }
        public decimal BuyPrice { get; }
    }
