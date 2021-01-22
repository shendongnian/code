    public Collection(IList<T> list)
    {
        if (list == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.list);
        }
        this.items = list;
    }
