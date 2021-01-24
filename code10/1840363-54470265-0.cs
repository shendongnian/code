    public class Response<T> where T : class {
        T data;
        string message;
        int statusCode //another field that would make error checking easier
    }
    public interface IRestService
    {
        Response<T> Post<T>(string path, string payLoad) where T : class;
    }
