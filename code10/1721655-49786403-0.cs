    /// <summary>
    /// Waits until a saga exists with the specified correlationId
    /// </summary>
    /// <param name="sagaId"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public async Task<Guid?> Exists(Guid sagaId, TimeSpan? timeout = null)
    /// <summary>
    /// Waits until at least one saga exists matching the specified filter
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public async Task<IList<Guid>> Match(Expression<Func<TSaga, bool>> filter, TimeSpan? timeout = null)
    /// <summary>
    /// Waits until the saga matching the specified correlationId does NOT exist
    /// </summary>
    /// <param name="sagaId"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public async Task<Guid?> NotExists(Guid sagaId, TimeSpan? timeout = null)
