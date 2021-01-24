    public MyRepository GetRepositoryForAccount(string accountId) {
        var nested = container.GetNestedContainer();
        var context = new ExecutionContext{ AccountId = accountId };
        return nested.GetInstance<IMyRepository>()
    }
