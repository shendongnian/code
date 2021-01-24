    public class Item
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
    public class ItemCollection
    {
        public decimal HighestPrice
        {
            get
            {
                decimal maxPrice = decimal.MinValue;
                foreach (Item item in Collection)
                {
                    if (item.Price > maxPrice)
                        maxPrice = item.Price;
                }
                return maxPrice;
            }
        }
        public decimal LowestPrice
        {
            get
            {
                decimal minPrice = decimal.MaxValue;
                foreach (Item item in Collection)
                {
                    if (item.Price < minPrice)
                        minPrice = item.Price;
                }
                return minPrice;
            }
        }
        public List<Item> Collection { get; set; }
    }
