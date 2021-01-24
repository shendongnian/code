    public interface IService<TRequest, TResponse> 
        where TRequest : IRequest 
        where TResponse : IResponse
    {
        TResponse Execute(TRequest request);
    }
    public interface IRequest
    {
        object Head { get; set; }
        object Body { get; set; }
    }
    public interface IResponse
    {
        string Message { get; set; }
        bool IsErrorOccured { get; set; }
    }
    public class MyServiceRequest : IRequest
    {
        //Interface property implementation here...
    }
    
    public class MyServiceResponse : IResponse
    {
        //Interface property implementation here...
    }
