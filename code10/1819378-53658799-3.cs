    public class Account
    {
        public string Pin { get; set; }
        public Account(string pin) { Pin = pin; }
    }
    static void Main()
    {
        // Sample data of existing account pins
        var accounts = new List<Account>
        {
            new Account("12345"),
            new Account("40597"),
            new Account("30894"),
            new Account("30498"),
            new Account("02467")
        };
        // Get new pin from user
        string newPin;
        while (true)
        {
            Console.Write("Enter a numeric pin: ");
            newPin = Console.ReadLine();
            // Ensure the string is all numbers
            if (!newPin.All(char.IsNumber))
            {
                WriteColorLine("Error - must be numeric digits only\n", ConsoleColor.Red);
                continue;
            }
            // Ensure that the pin is unique
            if (accounts.Any(account => account.Pin == newPin))
            {
                WriteColorLine("Error - pin already exists\n", ConsoleColor.Red);
                continue;
            }
            // If we got this far, the pin is all numbers and
            // doesn't exist so we can break out of the loop
            break;
        }
        // Create new account
        var userAccount = new Account(newPin);
        accounts.Add(userAccount);
        WriteColorLine("\nCongratulations, you have a new pin", ConsoleColor.Green);
            
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
