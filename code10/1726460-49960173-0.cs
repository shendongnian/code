    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();
            if (DateTime.Now.Hour == 1000)
            {
                Console.WriteLine(account.Name);
            }
        }
    }
