    public class Order
    {
        public string Id { get; set; }
        public string ItemName { get; set; }
    }
    public class Member : Order
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
