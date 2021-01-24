    static void Main(string[] args)
        {
            BookInfo bookInfo = new BookInfo()
            {
                Name = "Apple"
            };
            Console.WriteLine(callService(bookInfo));
        }
        private static string callService(BookInfo input)
        {
            string serviceUrl = "http://localhost:90/Service1.svc/booking";
            string stringPayload = "{\"bookInfo\":" + JsonConvert.SerializeObject(input) + "}";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string rtn = client.UploadString(serviceUrl, "POST",stringPayload);
            return rtn;
        }
