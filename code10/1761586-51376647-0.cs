    namespace ORDER_DATABASE.Tables
    {
        public class Order_Item
        {
            public int Id { get; set; }
            public int Amount { get; set; }
            public int? ProductId { get; set; }
            public virtual Order Order { get; set; }
            public virtual Product Product { get; set; }
        }
    }
