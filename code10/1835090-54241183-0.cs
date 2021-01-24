    static void AddCustomer()
    {
        Customer customer = new Customer();
        Database db = new Database();
        // declare the variable - populate its value later
        bool alreadyExists;
        do
        {
            Console.Write("Username: ");
            customer.Username = Console.ReadLine();
            // check the value the user just entered
            alreadyExists = db.Customer.Any(item => item.Username == customer.Username);
            if (alreadyExists)
            {
                Console.WriteLine("Username already exists");
            }
        }
        // if alreadyExists is true, repeat
        while (alreadyexists);
    }
