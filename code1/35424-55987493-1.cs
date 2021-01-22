    public class CustomerList : IEnumerable
    {
        Customer[] customers = new Customer[4];
        public CustomerList()
        {
            customers[0] = new Customer { Name = "Bijay Thapa", City = "LA", Mobile = 9841639665, Amount = 89.45 };
            customers[1] = new Customer { Name = "Jack", City = "NYC", Mobile = 9175869002, Amount = 426.00 };
            customers[2] = new Customer { Name = "Anil min", City = "Kathmandu", Mobile = 9173694005, Amount = 5896.20 };
            customers[3] = new Customer { Name = "Jim sin", City = "Delhi", Mobile = 64214556002, Amount = 596.20 };
        }
    
        public int Count()
        {
            return customers.Count();
        }
        public Customer this[int index]
        {
            get
            {
                return customers[index];
            }
        }
        public IEnumerator GetEnumerator()
        {
            return customers.GetEnumerator(); // we can do this but we are going to make our own Enumerator
            return new CustomerEnumerator(this);
        }
    }
