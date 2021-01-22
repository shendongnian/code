    public class ChargeCustomer 
    {
      private Customer[] customers;
      public ChargeCustomer( int charge, params string[] names)
      {
        customers = new Customer[names.Length];
        for(int i = 0; i < names.Length; i++) {
          customers[i] = new Customer(names[i], charge);
        }
      }
    }
