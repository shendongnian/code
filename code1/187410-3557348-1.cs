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
        public Customer[] PopulateCustomer() {
           return new [] {new Customer(1) {CustomerName = "Soham Dasgupta"},
                          new Customer(2) {CustomerName = "Bappa Sarkar"}};
        }
    }
    public abstract class MyColl<T> : IEnumerable<T>
    {
        protected T[] Items;
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in Items)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public class CustomerCollection : MyColl<Customer>
    {
        public CustomerCollection()
        {
            Items = new CustomerController().PopulateCustomer();
        }
    }
