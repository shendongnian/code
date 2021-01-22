    private Func<TEntity, TPropertyResult> PropertyAccessor { get; set; }
    private Func<TPropertyResult, bool> TestExpression { get; set; }
    private Func<TEntity, bool> Combined
    {
        get
        {
            return entity => TestExpression(PropertyAccessor(entity));
        }
    }
