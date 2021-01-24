    public class Items
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public ICollection<Orders> Orders { set; get; }
    }
