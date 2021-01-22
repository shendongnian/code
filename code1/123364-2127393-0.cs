    public static class CustomerFactory
    {
       public static Customer BuildCustomerWithId(_<int/short/long>_ primaryKeyId)
       {
          var customer = new Customer();
          return customer.GetCustomer(primaryKeyId);
       }
    }
