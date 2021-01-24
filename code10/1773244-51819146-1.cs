    public class BaseResponse<T>
    {
        public Session session { get; set; }
        public int httpStatus { get; set; }
        public Response Response { get; set; }
        public T Data {get; set;}
    }
    ...
    public class Data
    {
        public string img_stc {get; set;}
    }
