     public class FluentPerson
     {
        private string _FirstName = String.Empty;
        private string _LastName = String.Empty;
        public FluentPerson WithFirstName(string firstName)
        {
            _FirstName = firstName;
            return this;
        }
        public FluentPerson WithLastName(string lastName)
        {
            _LastName = lastName;
            return this;
        }
        public override string ToString()
        {
            return String.Format("First name: {0} last name: {1}", _FirstName, _LastName);
        }
    }
       public class FluentCustomer 
       {
           private string _AccountNumber = String.Empty;
           private string _id = String.Empty;
           FluentPerson objPers=new FluentPerson();
           
           public FluentCustomer WithAccountNumber(string accountNumber)
           {
               _AccountNumber = accountNumber;
               return this;
           }
           public FluentCustomer WithId(string id)
           {
               _id = id;
               return this;
           }
           public FluentCustomer WithFirstName(string firstName)
           {
               objPers.WithFirstName(firstName);
               return this;
           }
           public FluentCustomer WithLastName(string lastName)
           {
               objPers.WithLastName(lastName);
               return this;
           }
           public override string ToString()
           {
               return objPers.ToString() + String.Format(" account number: {0}",  _AccountNumber);
           }
       }
