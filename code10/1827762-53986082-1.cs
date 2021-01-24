    public void CreateAccount()
    {
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        Console.WriteLine("Create an Account");
        Client createAccount = new Client("Create");
        
        Console.WriteLine("Enter NameOfUser ");
        createAccount.NameOfUser = Console.ReadLine();
        Console.WriteLine("Enter SurnameOfUser ");
        createAccount.SurnameOfUser = Console.ReadLine();
        Console.WriteLine("Enter UserID ");
        createAccount.UserID = Console.ReadLine();
        Console.WriteLine("Enter UserEmail ");
        createAccount.UserEmail = Console.ReadLine();
        Console.WriteLine("Enter UserHomeAdd ");
        createAccount.UserHomeAdd = Console.ReadLine();
        Console.WriteLine("Enter UserMobileNumber ");
        createAccount.UserMobileNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter UsernameField ");
        createAccount.UsernameField = Console.ReadLine();
        Console.WriteLine("Enter PasswordField ");
        createAccount.PasswordField = Console.ReadLine();
        Console.WriteLine("Enter CoffePoints ");
        createAccount.CoffePoints = int.Parse(Console.ReadLine());
        List<Client> accountData = new List<Client>()
        {
            createAccount
        };
