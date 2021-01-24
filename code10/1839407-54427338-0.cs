    public TRepository Create<TRepository>(IConnection conn)
        where TRepository : IRepository, new()
    {
        return new TRepository(conn);
    }
