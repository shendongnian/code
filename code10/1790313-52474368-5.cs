    public static implicit operator ActionResult<TValue>(TValue value)
    {
        return new ActionResult<TValue>(value);
    }
    public static implicit operator ActionResult<TValue>(ActionResult result)
    {
        return new ActionResult<TValue>(result);
    }
