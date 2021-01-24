    private decimal _balance;
    public void AddTransaction(Transaction transaction)
    {
        _balance += transaction.Amount;
    }
    public decimal Balance => _balance;
