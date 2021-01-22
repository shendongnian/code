    public class ServerResult
    {
        public StatusCode Status { get; set; }
        public object Data { get; set; }
        public static ServerResult CreateServerResult(StatusCode status)
        {
            return new ServerResult() { Status = status };
        }
        public static ServerResult CreateServerResult(StatusCode status, object data)
        {
            return new ServerResult() { Data = data, Status = status };
        }
    }
