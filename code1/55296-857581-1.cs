    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public static Customer GetCurrentCustomer()
        {
            if (DatabaseConnectionExists())
            {
                return new Customer { FirstName = "Jim", LastName = "Smith" };
            }
            else
            {
                throw new Exception("Database connection does not exist.");
            }
        }
    
        public static bool DatabaseConnectionExists()
        {
            return true;
        }
    }
