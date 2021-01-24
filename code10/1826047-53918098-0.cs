    public class Response
    {
        public string Url { get; set; }
        public DateTime ServerTime { get; set; }
        public TimeSpan TimeTook { get; set; }
    }
    public class Response<T> : Response
    {
        public T Data { get; set; }
        public Error Error { get; set; }
        public static implicit operator Response<TData>(TData data)
        {
            var result = new Response<TData>
            {
              Data = data,
            };
            return result;
        }
        public static implicit operator Response<TData>(Error error)
        {
            var result = new Response<TData>
            {
              Error = error,
            };
            return result;
        }
    }
