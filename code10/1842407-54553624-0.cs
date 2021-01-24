    namespace PruebaRestful.Services
    {
        public class ContactRepository
        {
            private IConnection _connection;
            public ContactRepository(IConnection connection)
            {
                _connection = connection;
            }
            public Contact[] GetAllContacts()
            {
                return new Contact[]
                {
                new Contact
                {
                    Id = 1,
                    Name = "Glenn Block"
                },
                new Contact
                {
                    Id = 2,
                    Name = "Dan Roth"
                }
                };
            }
        }
    }
