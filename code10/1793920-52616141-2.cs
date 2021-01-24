    static void Main(string[] args)
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                ID = 1,
                Name = "Ahmed",
                Contacts = new List<Contact>
                {
                    new Contact {ID = 1, Name = "A", IsValid = true},
                    new Contact {ID = 2, Name = "B", IsValid = true},
                    new Contact {ID = 3, Name = "C", IsValid = true}
                }
            },
            new Customer
            {
                ID = 2,
                Name = "Mohamed",
                Contacts = new List<Contact>
                {
                    new Contact {ID = 4, Name = "D", IsValid = true},
                    new Contact {ID = 5, Name = "E", IsValid = true},
                    new Contact {ID = 6, Name = "F", IsValid = false}
                }
            },
            new Customer
            {
                ID = 3,
                Name = "Ali",
                Contacts = new List<Contact>
                {
                    new Contact {ID = 7, Name = "X", IsValid = false},
                    new Contact {ID = 8, Name = "Y", IsValid = false},
                    new Contact {ID = 9, Name = "Z", IsValid = false}
                }
            }
        };
        List<Customer> customersResult = customers.Select(GetCustomers).ToList();
        Console.Read();
    }
    private static Customer GetCustomers(Customer customer)
    {
        List<Contact> validContacts = new List<Contact>();
        if (customer.Contacts != null)
        {
            validContacts = customer.Contacts.Where(x => x.IsValid).ToList();
        }
        return new Customer
        {
            ID = customer.ID,
            Name = customer.Name,
            Contacts = validContacts
        };
    }
