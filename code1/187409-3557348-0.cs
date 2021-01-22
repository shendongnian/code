    public class Customer
    {
        public Customer(int customerID)
        {
            CustomerID = customerID;
        }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    }
    public class CustomerController
    {
        public ArrayList PopulateCustomer() {
            ArrayList Temp = new ArrayList();
            Customer _Customer1 = new Customer(1);
            Customer _Customer2 = new Customer(2);
            _Customer1.CustomerName = "Soham Dasgupta";
            _Customer2.CustomerName = "Bappa Sarkar";
            Temp.Add(_Customer1);
            Temp.Add(_Customer2);
            return Temp;
        }
    }
    public class CustomerCollection : IEnumerable<Customer>, IEnumerator
    {
        ArrayList Customers;
        IEnumerator CustomerEnum;
        public CustomerCollection() {
            Customers = new CustomerController().PopulateCustomer();
            CustomerEnum = Customers.GetEnumerator();
        }
        public void SortByName(){
            Reset();
        }
        public void SortByID(){
            Reset();
        }
        public IEnumerator<Customer> GetEnumerator() {
            return (IEnumerator<Customer>)this;
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this;
        }
        public void Reset() {
            CustomerEnum.Reset();
        }
        public bool MoveNext() {
            return CustomerEnum.MoveNext();
        }
        public object Current { get { return CustomerEnum.Current; } }
    }
