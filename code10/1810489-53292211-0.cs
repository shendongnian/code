    public class Transaction
    {
        public enum Type { Open, Close, Deposit, Withdrawl, Inquiry, Other }
        public Type TransactionType { get; }
        public string Description { get; }
        public DateTime Timestamp { get; }
        public Transaction(Type transactionType, string description)
        {
            TransactionType = transactionType;
            Description = description;
            Timestamp = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Timestamp}: {TransactionType} - {Description}";
        }
    }
    public class Account
    {
        public enum Type { Checking, Savings }
        public Type AccountType { get; }
        public int Id { get; }
        public List<Transaction> Transactions { get; private set; }
        private static readonly object IdLock = new object();
        private static int _lastAccountId;
        private readonly object balanceLock = new object();
        private decimal balance;
        public Account(decimal initialDeposit, Type accountType)
        {
            if (initialDeposit < 0)
            {
                throw new ArgumentOutOfRangeException("initialDeposit cannot be negative");
            }
            AccountType = accountType;
            balance = initialDeposit;
            lock (IdLock)
            {
                Id = ++_lastAccountId;
            }
            AddTransaction(Transaction.Type.Open, 
                $"{AccountType} account Id {Id} created with a deposit of: {balance:C}.");
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount cannot be negative");
            }
            lock (balanceLock)
            {
                balance += amount;
                AddTransaction(Transaction.Type.Deposit,
                    $"{amount} was deposited. New balance: {balance:C}.");
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Withdrawl amount cannot be negative");
            }
            if (amount > balance)
            {
                throw new ArgumentOutOfRangeException(
                    "Cannot withdraw more money than the account contains");
            }
            lock (balanceLock)
            {
                balance -= amount;
                AddTransaction(Transaction.Type.Withdrawl,
                    $"{amount} was withdrawn. New balance: {balance:C}.");
            }
        }
        public decimal GetBalance()
        {
            lock (balanceLock)
            {
                AddTransaction(Transaction.Type.Inquiry,
                    $"Balance inquiry made. Balance: {balance:C}.");
                return balance;
            }
        }
        private void AddTransaction(Transaction.Type transactionType, string description)
        {
            if (Transactions == null) Transactions = new List<Transaction>();
            Transactions.Add(new Transaction(transactionType, description));
        }
    }
