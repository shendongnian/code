    // In TableCountTest:
    public void Execute(IProcessContext context) =>
        Test(context.Id);
    // In CompareTest:
    public void Execute(IProcessContext context) =>
        Compare(context.Id, context.S, context.D);
