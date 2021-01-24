    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();
            if (account.GetType().GetProperty("Name") != null)
            {
                PrintAccountName(account);
            }
            else
            {
                Console.WriteLine("Account.Name is missing");
            }
        }
        
        static void PrintAccountName(Account account)
        {
            Console.WriteLine($"Account name: {account.Name}");
        }
    }
