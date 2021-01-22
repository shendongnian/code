    public interface IResult 
    {
        void DoSomething();
    }
    public class TestResult : IResult { ... }
    public class ResultLinks : IResult { ... }
    public List<List<T>> BatchResultsList<T>(List<T> objectList) where T : IResult
    {
        foreach(T t in objectList)
        {
            t.DoSomething();
            // do something with T.
            // note that since the type of T is constrained to types that implement 
            // IResult, you can access all properties and methods defined in IResult 
            // on the object t here
        }
    }
