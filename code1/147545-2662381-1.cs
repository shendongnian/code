    class A {}
    class B : A {}
    public void SomeFunction()
    {
        var someListOfB = new List<B>();
        someListOfB.Add(new B());
        someListOfB.Add(new B());
        someListOfB.Add(new B());
        SomeFunctionThatTakesA(someListOfB);
    }
    public void SomeFunctionThatTakesA(IEnumerable<A> input)
    {
        // Before C# 4, you couldn't pass in List<B>:
        // cannot convert from
        // 'System.Collections.Generic.List<ConsoleApplication1.B>' to
        // 'System.Collections.Generic.IEnumerable<ConsoleApplication1.A>'
    }
