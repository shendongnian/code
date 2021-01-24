	public class JsonResponse
    {
        public string Error { get; set; }
        public object Result { get; set; }
        public bool IsSuccess { get; set; }
        public Httpresponse HttpResponse { get; set; }
    }
    public class Httpresponse
    {
        public Header[] Headers { get; set; }
        public string ContentBody { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public string RequestUri { get; set; }
        public string RequestBody { get; set; }
    }
    public class Header
    {
        public string Key { get; set; }
        public string[] Value { get; set; }
    }
