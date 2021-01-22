    public class Customer : EntityBase
    {
        private int year;
    
        public Customer(int year)
        {
            this.year = year;
        }
    
        public void CreateCustomer(Customer c)
        {
            Create(c);
        }
    
        protected override void Validate()
        {
            if (year < 1900)
            {
                throw new Exception("Too old");
            }
        }
    }
