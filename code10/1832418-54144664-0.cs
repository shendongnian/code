    public interface IResult
    {
        Foo Foo { get; }
    }
    
    public class Result : IResult
    {
        public static IResult NoResult = new NoResult();
    
        public Foo Foo { get; private set; }
    
        public Result(Foo foo)
        {
           Foo = foo;
        }
    
        private class NoResult : IResult
        {
            public Foo Foo => throw new NotImplementedException("Null object!");
        }
    }
