    public struct Money
    {
        public string Currency { get; set; }
        public double Amount { get; set; }
    }
    public struct PhoneNumber
    {
        public int Extension { get; set; }
        public int RegionCode { get; set; }
        //... etc.
    }
    public struct FullName
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
