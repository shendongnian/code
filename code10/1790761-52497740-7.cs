    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:2000/BookInfo";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            BookInfo input = new BookInfo()
            {
                Name = "Apple"
            };
            string str2 = "{\"bookInfo\":" + JsonConvert.SerializeObject(input) + "}";
            string result = client.UploadString(uri, "POST", str2);
            Console.WriteLine(result);
        }
    }
    [DataContract]
    public class BookInfo
    {
        [DataMember]
        public string Name { get; set; }
    }
