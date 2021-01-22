    SomeObject GetSomeObjectById(Int32 id)
    {
        SomeObject o;
        if (!TryGetObjectById(id, ref o))
        {
            throw new SomeAppropriateException();
        }
        return o;
    }
