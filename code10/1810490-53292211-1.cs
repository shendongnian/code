    static void Main(string[] args)
    {
        // Adding accounts in the same order as they appear on your form
        var accounts = new List<Account>
        {
            new Account(293.05M, Account.Type.Checking),
            new Account(293.05M, Account.Type.Checking),
            new Account(300M, Account.Type.Savings),
            new Account(300M, Account.Type.Savings),
        };
        // Sort transactions by account Id
        List<Transaction> transactions = accounts
                .OrderBy(a => a.Id)
                .SelectMany(a => a.Transactions)
                .ToList();
        // Write results to Console
        transactions.ForEach(Console.WriteLine);
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
