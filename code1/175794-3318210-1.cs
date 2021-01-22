    // this is a good candidate for optional parameters
    public void DoSomething(int requiredThing, int nextThing = 12, int lastThing = 0)
    // this is not, because it should be one or the other, but not both
    public void DoSomething(Stream streamData = null, string stringData = null)
    // these are good candidates for overloading
    public void DoSomething(Stream data)
    public void DoSomething(string data)
    // these are no longer good candidates for overloading
    public void DoSomething(int firstThing)
    {
        DoSomething(firstThing, 12);
    }
    public void DoSomething(int firstThing, int nextThing)
    {
        DoSomething(firstThing, nextThing, 0);
    }
    public void DoSomething(int firstThing, int nextThing, int lastThing)
    {
        ...
    }
