    public int DoSomething(Base variable)
    {
        // Do stuff
    }  
    public int DoSomethingElse(Derived variable)
    {
        return DoSomething((Base)variable);
    }
