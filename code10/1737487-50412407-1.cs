    public class Employee
    {
        //It can be a Guid, string or what ever. I am not nesseserly recomending using Guids and you should look into this a bit more   
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Bank { get; set; }
        public string Account { get; set; }
    }
    public class DaysData
    {
        public Guid Id { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
    public class Product
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public double Count { get; set; }
        public double Price { get; set; }
    }
    public class Earnings
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public double Money { get; set; }
    }
