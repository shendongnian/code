    // File: Person.cs
    public class Person {
        public string Name { get; set; }
        public string Number { get; set; }
        // Some other general properties...
    }
    // File: Customer.cs
    public class Customer : Person {
        public Customer() {
            Orders = new List<Order>();
        }
        public string CreditTerm { get; set; }
        public IList<Order> Orders { get; }
    }
    // File: Contact.cs
    public class Contact : Person {
        public long PhoneNumber { get; set; }
        public long FaxNumber { get; set; }
    }
    // File: Supplier.cs
    public class Supplier : Person {
        public Supplier() {
            Salesperson = new Contact();
        }
        public Contact Salesperson { get; }
    }
