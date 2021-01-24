    Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-");
    Console.WriteLine("Enter a Username: ");
    Client usernameField = new Client("Username")
    {
        UsernameField = Console.ReadLine()
    };
    var listOfClients = Client.DeserilizeData(fileName);
    var exists = listOfclients.Any(x=>x.UsernameField.Equals(usernameField.UsernameField ));
