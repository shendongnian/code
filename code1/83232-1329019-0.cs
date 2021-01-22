    public void GettingCastReturnsCastedType()
    {
        IStub stub = new Stub(); // casted as an IStub
        Type type = GetCast(stub); // see what this returns
    }
