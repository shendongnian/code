        class Request
    {
        public String type { get; set; }
        public String url { get; set; }
        public String host { get; set; }
        public String data { get; set; }
        private Request(String type,String url,String host)
        {
            this.type = type;
            this.url = url;
            this.host = host;
        }
        private Request(String type, String url, String host,String data)
        {
            this.type = type;
            this.url = url;
            this.host = host;
            this.data = data;
        }
        public static Request GetRequest(String request)
        {
            if (String.IsNullOrEmpty(request))
                return null;
            String[] tokens = request.Split(' ');      
            String type = tokens[0];
            String url = tokens[1];
            String host = tokens[4];
            String data = "N/A";
            if (tokens.Length >= 9)
            {
                data = tokens[8];
            }
            return new Request(type, url, host, data);
        }
    }
