    public T get_Value()
    {
        if (!this.HasValue)
        {
            ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_NoValue);
        }
        return this.value;
    }
 
