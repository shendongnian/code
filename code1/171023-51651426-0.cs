    public class ReturnString : IReq<string>
    {
    }
    public class ReturnInt : IReq<int>
    {
    }
    public interface IReq<T>
    {
    }
    public class Handler
    {
        public T MakeRequest<T>(IReq<T> requestObject)
        {
            return default(T);
        }
    }
            
    var handler = new Handler();
    string stringResponse = handler.MakeRequest(new ReturnString());
    int intResponse = handler.MakeRequest(new ReturnInt());
