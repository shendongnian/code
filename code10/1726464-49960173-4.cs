    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();
            if (DateTime.Now.Hour == 1000)
            {
                PrintAccountName(account);
            }
        }
        
        static void PrintAccountName(Account account)
        {
            Console.WriteLine(account.Name);
        }
    }
