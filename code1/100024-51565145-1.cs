    async Task<(bool success, SomeObject o)> TryGetSomeObjectByIdAsync(Int32 id)
    {
        if (InternalIdExists(id))
        {
            o = await InternalGetSomeObjectAsync(id);
    
            return (true, o);
        }
        else
        {
            return (false, default(SomeObject));
        }
    }
