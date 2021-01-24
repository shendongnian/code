    public class Employee : PersonDecorator
    {
        public Employee(Person person = null) : base(person ?? new Person()) { }
        public override string Name => $"Employee, {base.Name}";
        public string Job { get; set; }
    }
    
    public class Customer : PersonDecorator
    {
        public Customer(Person person) : base(person ?? new Person()) { }
        public override string Name => $"Customer, {base.Name}";
        public bool IsShopping { get; set; }
    }
