    class CustomerList  : List<Customer>
    {
        public void Add(string name, string phoneNumber, string city, string stateOrCountry)
        {
            Add(new Customer(name, phoneNumber, city, stateOrCounter));
        }
    }
