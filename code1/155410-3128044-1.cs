    /* e.g. T = IDataAccess<Customer>, K = Customer */
    public class DataRespository<T>
       where T : IDataAccess<K>, new()
       where K : YourBaseObject, new()
    {
    
        private T _base;
        public T BaseRepository { 
              get { 
                 if(_base == null)
                     _base = Activator.CreateInstance<T>(); 
                 return _base;
              } 
        }
        public void Update(K item) { /* functionality for YourBaseObject */ }
        public void Save(K item) { /* functionality for YourBaseObject */ }
        public void Remove(K item) {  /* functionality for YourBaseObject */ }
    }   
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new CustomerDataAccess();
            Customer c = new Customer {
                Age = 10,
                EmailAddress = "this@demo.com"
            };
            repository.Save(c);
            // This pass-through is no longer needed, but shown as example
            // repository.BaseRepository.PerformCustomerOnlyAction(c);
            repository.PerformCustomerOnlyAction(c);
        }
    }
