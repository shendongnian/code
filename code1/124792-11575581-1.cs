    public class ServerResult<T>
    {
        public StatusCode Status { get; set; }
        public T Data { get; set; }
        public static ServerResult<T> CreateServerResult(StatusCode status)
        {
            return new ServerResult<T>() { Status = status };
        }
        public static ServerResult<T> CreateServerResult(StatusCode status, T data)
        {
            return new ServerResult<T>() { Data = data, Status = status };
        }
    }
    
