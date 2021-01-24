    public interface ISettings
    {
        string SomePropertyOnlyForTrue { get; }
        int B { get; }
    }
    
    public interface IBuilderFoo
    {
        IBuilderFooTrue BuildFooTrue();
        IBuilderFooFalse BuildFooFalse();
    }
    
    public interface IBuilderFooTrue
    {
        IBuilderFooTrue WithSomePropertyOnlyForTrue(string value);
        ISettings Build();
    }
    
    public interface IBuilderFooFalse
    {
        IBuilderFooFalse WithB(int value);
        ISettings Build();
    }
    
    public void Whatever()
    {
        var theThingTrue = new BuilderFoo().BuildFooTrue()
            .WithSomePropertyOnlyForTrue("face").Build();
        var theThingTrueCompilerError = new BuilderFoo().BuildFooTrue()
            .WithB(5).Build(); // compiler error
    
        var theThingFalse = new BuilderFoo().BuildFooFalse()
            .WithB(5).Build();
        var theThingFalseCompilerError = new BuilderFoo().BuildFooFalse()
            .WithSomePropertyOnlyForTrue("face").Build(); // compiler error
    }
