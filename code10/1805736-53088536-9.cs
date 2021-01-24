    public class Employee : Person
    {
        public override string Name => $"Employee, {base.Name}";
        public string Job { get; set; }
    }
    
    public class Customer : Person
    {
        public override string Name => $"Customer, {base.Name}";
        public bool IsShopping { get; set; }
    }
