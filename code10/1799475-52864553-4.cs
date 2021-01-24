    public class ApiResponse
    {
        public Response Response { get; set; }
    }
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }
    }
