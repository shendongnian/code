    class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("http://stream.twitter.com/spritzer.json");
            request.Credentials = new NetworkCredential("username", "password");
            request.BeginGetResponse(ar => 
            {
                var req = (WebRequest)ar.AsyncState;
                // TODO: Add exception handling: EndGetResponse could throw
                using (var response = req.EndGetResponse(ar))
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }, request);
            // Press Enter to stop program
            Console.ReadLine();
        }
    }
