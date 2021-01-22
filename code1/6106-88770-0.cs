    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
    public class Customer
    {
      [StringLengthValidator(0, 20)]
      public string CustomerName;
    
      public Customer(string customerName)
      {
        this.CustomerName = customerName;
      }
    }
