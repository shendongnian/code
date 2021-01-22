    interface ICustomerCollection
    {
          void Add(string customerName);
          void Delete(string customerName);
    }
    class CustomerCollection : ICustomerCollection
    {
          public void Add(string customerName)
          {
                /*Customer collection add method specific code*/
          }
          public void Delete(string customerName)
          {
                /*Customer collection delete method specific code*/
          }
    }
      
    class MyUserControl: UserControl, ICustomerCollection
    {
          CustomerCollection _customerCollection=new CustomerCollection();
         
          public void Add(string customerName)
          {
                _customerCollection.Add(customerName);
          }
          public void Delete(string customerName)
          {
                _customerCollection.Add(customerName);
          }
    }
