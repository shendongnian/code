    Console.WriteLine(Transaction.Current != null); // false
    using (TransactionScope tran = new TransactionScope())
    {
        Console.WriteLine(Transaction.Current != null); // true
        using (TransactionScope tran2 = new TransactionScope(
              TransactionScopeOption.Suppress))
        {
            Console.WriteLine(Transaction.Current != null); // false
        }
        Console.WriteLine(Transaction.Current != null); // true
    }
    Console.WriteLine(Transaction.Current != null); // false
