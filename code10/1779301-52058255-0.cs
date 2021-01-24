    public class Invoice
    {
        public string ContactName { get; set; }
        public List<Item> LineItems { get; set; } = new List<Item>();
        public string InvoiceNumber { get; set; }
    }
    public class Item
    {
        public double Quantity { get; set; }
        public string Description { get; set; }
    }
