    public static IEnumerable<UnboundTag> GetUnboundTagsRecursively
       (Type bindingType)
    {
        Contract.Requires(bindingType != null);
        Contract.Ensures(Contract.Result<IEnumerable<UnboundTag>>() != null);
        IEnumerable<UnboundTag> ret = GetUnboundTagsRecursivelyImpl(bindingType);
        // We know it won't be null, but iterator blocks are a pain.
        Contract.Assume(ret != null);
        return ret;
    }
