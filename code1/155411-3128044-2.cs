    public interface IDataAccess<T> : where T : YourBaseObject {
       public void Update(T item);
       public void Save(T item);
       public void Remove(T item);
    }
    
    public class Customer : YourBaseObject {
        public int CustomerID { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
    }
    
    public class CustomerDataAccess : 
        DataRespository<IDataAccess<Customer>> {
        public void PerformCustomerOnlyAction(Customer customer) { 
         /* do stuff */
        }
    }
    
