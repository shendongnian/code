    public int IndexOf(T item)
    {
        Contract.Requires(item != null);
        Contract.Requires((item as IEntity).ID > 0);
    ...
