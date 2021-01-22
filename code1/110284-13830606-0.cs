    class Base {
    protected static SomeObjectType myVariable;
    
    protected void doSomething()
    {
    Console.WriteLine( myVariable.SomeProperty );
    }
    }
    
    class AAA : Base
    {
    static AAA()
    {
    myVariable = new SomeObjectType();
    myVariable.SomeProperty = "A";
    }
    }
    
    class BBB : Base
    {
    static BBB()
    {
    myVariable = new SomeObjectType();
    myVariable.SomeProperty = "B";
    }
    }
