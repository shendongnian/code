    public class CustomerController 
    { 
        public List<Customer> PopulateCustomer() 
        { 
            List<Customer> Temp = new ArrayList(); 
     
            Customer _Customer1 = new Customer(1); 
            Customer _Customer2 = new Customer(2); 
     
            _Customer1.CustomerName = "Soham Dasgupta"; 
            _Customer2.CustomerName = "Bappa Sarkar"; 
     
            Temp.Add(_Customer1); 
            Temp.Add(_Customer2); 
     
            return Temp; 
        } 
    } 
    
    
    public class CustomerCollection : List<Customer>
    {  
        List<Customer> Customers = new List<Customer>();  
     
      
        public CustomerCollection()  
        {  
            this.Customers = new CustomerController().PopulateCustomer();  
        }    
    
    }  
