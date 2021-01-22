    SomeObject GetSomeObjectById(Int32 id)
    {
        SomeObject o;
        if (!TryGetObjectById(id, out o))
        {
            throw new SomeAppropriateException();
        }
        return o;
    }
