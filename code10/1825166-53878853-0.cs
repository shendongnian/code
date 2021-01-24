    public async Task<string> ExecuteTransactionAsync(ITransaction transaction) {
        var taskResult = await Task.Run(transaction.Execute);
        //...
        return taskResult;        
    }
