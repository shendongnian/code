    class Person { }
    class Employee: Person { }
    class Member : Employee
    {
        public IList<Order> Orders { get; private set; }
    }
    
    class Order
    {
       public int MemberId { get; private set; }
    }
