    public class Order
    {
        public int ID { get; set; }
        public int Created { get; set; }
        public List<Item> Items { get; set; }
        public override string ToString()
        {
            string fakeItem = "";
            if(Items.Count > 2) 
                fakeItem = Environment.NewLine + @""""", """", ""Y"" "; // or whatever you want.
            return string.Join(@"{0}, {1}, {2}, {3}", 
                ID, 
                Created == 0 ? "Y" : "N", 
                string.Join(", ", from item in Items.Take(2) select item.ToString()),
                fakeItem);
        }
    }
    public class Item
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return string.Format(@"{0}, {1}", Sku, Quantity);
        }
    }
