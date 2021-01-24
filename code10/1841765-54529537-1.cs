    public abstract class Result<T>
    {
        public T Response { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Version { get; set; }
    }
