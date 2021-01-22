    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                var data = File.ReadAllText("request.xml");
                var response = client.UploadString("http://.../Service.svc", "POST", data);
            }
        }
    }
