    public class Customer : Person
    {
        private string _firstName;
        private string _lastName;
        private Customer() { }
        public Customer(string firstName, string lastName) //but this calls it anyway, why?
        {
            _firstName = firstName;
            _lastName = lastName;
        }
        ...
    }
