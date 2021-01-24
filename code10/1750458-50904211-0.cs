    public class Response<TResult>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public DateTime ResponseDateTime { get; set; }
    }
