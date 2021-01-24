    public class Buyable
    {
        public int id { get; set; }
        public string sku { get; set; }
        public int game_id { get; set; }
        public string title { get; set; }
        public int min_qty { get; set; }
        public int max_qty { get; set; }
        public string base_price { get; set; }
        public string sale_price { get; set; }
        public Bulk_Price[] bulk_price { get; set; }
        public string delivery_time { get; set; }
        public string description { get; set; }
        public object sort_order { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string price { get; set; }
        public bool on_sale { get; set; }
        public int discount_from { get; set; }
    }
    
    public class Bulk_Price
    {
        public string qty { get; set; }
        public string price { get; set; }
    }
