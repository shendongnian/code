    //Write your Test first
    public class Test
    {
        public void TestEnumerator()
        {
            var customers = new CustomerCollection();
            var qry = 
                from c in customers
                select c;
            
            foreach (var c in qry)
            {
                Console.WriteLine(c.CustomerName);
            }
            //Create a new list from the collection:
            var customerList = new List<Customer>(customers);
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
    
    public class CustomerCollection : MyColl<Customer>
    {
        public CustomerCollection()
        {
            Items = new CustomerController().PopulateCustomer();
        }
    }
