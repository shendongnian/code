    class Customer 
    {
        public Customer(string fname, string lname, string address, DateTime dob, int? phone=null, string email=null) { 
          // just check if phone has a value
          if (phone.HasValue) {
            // do something with phone.Value;    
          }
          // and check is email is not null
          if (email != null) { }
        }
    }
