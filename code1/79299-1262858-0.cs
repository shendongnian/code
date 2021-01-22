    class CustomerDAO
    {
       private bool _LoadPartial = true;
       public bool LoadPartial
       {
          get
          {
             return _LoadPartial;
          }
    
          set
          {
             _LoadPartial = value;
          }
       }
    
       
       public Collection<Customer> FindAllCustomers()
       {
          ...
       }
    }
