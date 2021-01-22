    public interface IInterface<TResult, TInput>
    {
        TResult GetResponseData(TInput response);
    }
    // usage
    public class ImplementerOfIInterface : IInterface<string, int>
    {
        // ...
        string GetResponseData( int response ) {/*  code */}
        // ... 
    }
