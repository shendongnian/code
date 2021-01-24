        public static class Factory
        {
            private static int currentId = 0;
            public static Person Create(string firstName, string lastName, string phoneNumber, int companyId)
            {
                return new Person()
                {
                    Id = ++currentId,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    CompanyId = companyId
                };
            }
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public int CompanyId { get; private set; }
    }
    public class Company
    {
        public static class Factory
        {
            private static int companyId=0;
            public static Company Create(string name, string city, string state, string phoneNumber)
            {
                return new Company()
                {
                    Id = ++ companyId,
                    City = city,
                    State = state,
                    Name = name,
                    PhoneNumber = phoneNumber
                };
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
    }
