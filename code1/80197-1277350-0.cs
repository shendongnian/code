    public class Customer {
      public string HomePhoneString;
    
      private bool _HomePhoneParsed;
      private PhoneNumber? _HomePhone;
      public PhoneNumber? HomePhone
      {
        get
        {
          if(!_HomePhoneParsed)
          {
            _HomePhone = PhoneNumber.TryParse(HomePhoneString);
            _HomePhoneParsed = true;
          }
          return _HomePhone;
        }
      }
    }
    
    public IQueryable<Customers> GetCustomers() {
      var customers = (from c in DataContext.Customers
      select new Customer {
        HomePhoneString = c.HomePhone
      });
      return customers;
    }
