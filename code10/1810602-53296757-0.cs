    public List<object> handleSummaryOfWallets()
    {
    }
    
    var listOfBalances = await Task.Run(() => balances.handleSummaryOfWallets());
