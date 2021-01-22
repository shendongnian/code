    Boolean TryGetSomeObjectById(Int32 id, ref SomeObject o)
    {
        if (InternalIdExists(id))
        {
            o = InternalGetSomeObject(id);
            return true;
        }
        else
        {
            return false;
        }
    }
