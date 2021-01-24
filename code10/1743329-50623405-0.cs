    public class Purchase
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Virtual Employee Employee { get; set; }
        public DateTime PurchaseDate{get;set;}
        public int SupplierId { get; set; }
        public Virtual Supplier Supplier { get; set; }
        public string Remarks { get; set; }
        public double GrandTotal { get; set; }
        public List<PurchaseDetails> PurchaseDetailses { get; set; }
        public int OutletId { get; set; }
        public Virtual Outlet Outlet { get; set; }
        public List<Outlet> Outlets { get; set; }
    }
