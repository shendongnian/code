    [Conditional("DEBUG")]
    private void CheckObjectInvariant()
    {
        Debug.Assert(name != null);
        Debug.Assert(name.Length <= nameMaxLength);
        ...
    }
