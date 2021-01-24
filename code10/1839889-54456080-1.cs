    public class Customer
    {
        public int Id { get; set; }
        public int Resp_Id { get; set; }
        public string Name { get; set; }
    }
    public class Billing
    {
        public int Id { get; set; }
        public double? Day30 { get; set; }
        public double? Day60 { get; set; }
    }
