    public class Response<T> where T : class
    {
        public string errorMessage { get; set; }
        public string status { get; set; }
        public string totalPages { get; set; }
        public IList<T> ResponseBody { get; set; }
    }
