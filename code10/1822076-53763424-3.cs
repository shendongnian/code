    public MyRepository GetRepositoryForAccount(string accountId) {
        var nested = container.GetNestedContainer();
        var context = new ExecutionContext{ AccountId = accountId };
        nested.Inject(context);
        return nested.GetInstance<IMyRepository>()
    }
