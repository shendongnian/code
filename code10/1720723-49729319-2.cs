    //Example 1 - Simple property
    public class Customer
    {
        public string Name { get; set; }
    }
    //Example 2 - Publically gettable (but not settable) property with private field (which is settable)
    public class Customer
    {
        private string _name;          //this is a field
        public string Name => _name;   //this is a property that relies on the field
    }
