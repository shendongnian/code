    class Customer
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTelNo { get; set; }
        public var Branches = new List<Branch>();
    }
    class Branch
    {
        public Guid BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchTelNo { get; set; }
        public var Customers = new List<Customer>();
    }
