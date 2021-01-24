    public class Customer
    {
       public int CustomerNumber {get; set;}
       public virtual ICollection<CustomerDetails> CustomerDetails {get; set;}
    }
    
    public class CustomerDetails
    {
       public int CustomerDetailId {get; set;}
       public string Role {get; set;}
       public int CustomerNumber {get; set;}
    }
