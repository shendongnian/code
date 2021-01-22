    class Customer
    {
        // Auto-Impl Properties for trivial get and set
        public double TotalPurchases { get; set; }
        public string Name { get; set; }
        public int CustomerID { get; set; }
    
        // Constructor
        public Customer(double purchases, string name, int ID)
        {
            TotalPurchases = purchases;
            Name = name;
            CustomerID = ID;
        }
        // Methods
        public string GetContactInfo() {return "ContactInfo";}
        public string GetTransactionHistory() {return "History";}
    
        // .. Additional methods, events, etc.
    }
 
