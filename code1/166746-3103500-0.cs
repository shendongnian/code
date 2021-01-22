    public static IEnumerable<UnboundTag> GetUnboundTagsRecursively
       (Type bindingType)
    {
        Contract.Requires(bindingType != null);
        Contract.Ensures(Contract.Result<IEnumerable<UnboundTag>>() != null);
        return GetUnboundTagsRecursivelyImpl(bindingType);
    }
    private static IEnumerable<UnboundTag> GetUnboundTagsRecursively
        (Type bindingType)
    {
        // Iterator block code here
    }
