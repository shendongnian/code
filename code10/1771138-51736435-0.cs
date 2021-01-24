    public class APIResponse<T> where T: class
    {
        public int statusCode { get; set; }
        public string errorMessage { get; set; }
        public T returnObject { get; set; }
    }
