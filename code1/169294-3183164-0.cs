    public class Customer : KeyedObject
    {
    
       public Customer(int customerId)
       {
          _customerRepository.Load(this);
    
          ICustomerTypeRepository _customerTypeRepository = IoC.Resolve(..);
          _customerTypes = _customerTypeRepository.GetList();
       }
    
       private ICustomerRepository _customerRepository = IoC.Resolve(..);  
    
       public virtual string CustomerName {get;set;}
       public virtual int CustomerTypeId {get;set;}
    
       public virtual string CustomerType
       {
          get
          {
             return _customerTypes.Find(CustomerTypeId);
          }
       }
    
       private IEnumerable<CustomerType> _customerTypes;
       public virtual IEnumerable<CustomerType> CustomerTypes
       {
          get
          {
              return _customerTypes
          }
       }
    }
