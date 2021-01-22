    namespace StructThreadSafe
    {
        class Program
        {
            struct BankBalance
            {
                public decimal Balance { get; set; }
            }
    
            static void Main(string[] args)
            {
                BankBalance bankBalance = new BankBalance();
                bankBalance.Balance = 100;
                List<Task> allTasks = new List<Task>();
                for (int q = 0; q < 10; q++)
                {
                    Task producer = new Task(() =>
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            if (bankBalance.Balance < 0)
                            {
                                if (Debugger.IsAttached)
                                {
                                    Debugger.Break();
                                }   
                            }
                            bankBalance.Balance += 5;
                            Console.WriteLine("++Current Balance: " + bankBalance.Balance);
                            System.Threading.Thread.Sleep(100);
                        }
                    });
                    allTasks.Add(producer);
                }
                for (int w = 0; w < 10; w++)
                {
                    Task consumer = new Task(() =>
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            if (bankBalance.Balance < 0)
                            {
                                if (Debugger.IsAttached)
                                {
                                    Debugger.Break();
                                }
                            }
                            if (bankBalance.Balance > 15)
                            {
                                bankBalance.Balance -= 15;
                                Console.WriteLine("--Current Balance: " + bankBalance.Balance);
                            }
                            else
                            {
                                Console.WriteLine("**Current Balance below minimum: " + bankBalance.Balance);
                            }
                            System.Threading.Thread.Sleep(100);
                        }
                    });
                    allTasks.Add(consumer);
                }
                allTasks.ForEach(p => p.Start());
                Task.WaitAll(allTasks.ToArray());
    
            }
        }
    }
