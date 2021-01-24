    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new Dictionary<int, BankAccount>();
            string[] command;
            do
            {
                command = Console.ReadLine().Split();
                if (command[0] == "Create")
                    Create(command, accounts);
            } while (command[0] != "End");
            Console.Read();
        }
        private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            if (accounts.ContainsKey(id))
                Console.WriteLine("Account already exists");
            else
                accounts.Add(id, new BankAccount { ID = id });
        }
    }
    class BankAccount
    {
        public double Balance { get; set; }
        public int ID { get; set; }
        public override string ToString() => $"Account {ID} has {Balance}";
        public void Deposit(double amount) => Balance += amount;
        public void Withdraw(double amount) => Balance -= amount;
    }
