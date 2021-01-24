    class Program {
        static void Main(string[] args) {
            var response = Post(...);
            if(response.Status == "success") {
                //ok
            } else {
                //request failed
            }
        }
        public static string Post(string requestUriString, string s) {
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            var data = Encoding.ASCII.GetBytes(s);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream()) {
                stream.Write(data, 0, data.Length);
            }
            try {
                var response = (HttpWebResponse)request.GetResponse();
                var body = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return new Response("success", body);
            } catch (WebException webException) {
                Console.WriteLine(webException);
                return new Response("failed", "");
            }
        }
        class Response {
            public string Status { get; private set; }
            public string Body { get; private set; }
            public Response(string status, string response) {
                Status = status;
                Body = response;
            }
        }
    }
