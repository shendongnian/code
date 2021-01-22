    public sealed class RequestHeader
    {
        public static RequestHeader Accept = new RequestHeader("Accept");
        public static RequestHeader AcceptCharset = 
            new RequestHeader("Accept-Charset");
        private readonly string name;
        private RequestHeader(string header)
        {
            this. name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }
