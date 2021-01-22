    Bar myBar = new Bar();
    Baz myBaz = new Baz();
    
    doSomething(myBar);
    doSomething(myBaz);
    public void doSomething(ICommon parameter)
    {
        parameter.DoICommonThing(); // working on object of type ICommon.
    }
