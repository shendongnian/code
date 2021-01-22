    class CustomerRepository{
        // Only one static variable    
        public static CustomerRepository Repository = new CustomerRepository();
    
        // all methods are instance methods..
        public IEnumerable GetAll(){
        ...
        }
    
    }
