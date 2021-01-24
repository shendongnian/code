    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();
            if (account.GetType().GetProperty("Name") != null)
            {
                // Avoid a compile-time reference to the property
                dynamic d = account;
                Console.WriteLine($"Account name: {d.Name}");
            }
            else
            {
                Console.WriteLine("Account.Name is missing");
            }
        }
    }
