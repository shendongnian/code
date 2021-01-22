    public static void GetStatusesFromStream(string username, string password, int nMessageCount)
        {
            WebRequest request = WebRequest.Create("http://stream.twitter.com/1/statuses/sample.json");
            request.Credentials = new NetworkCredential(username, password);
            WebResponse response = request.GetResponse();
            {
                var stream = response.GetResponseStream();
                {
                    var reader = new StreamReader(stream);
                    {
                        while (!reader.EndOfStream)
                        {
                            Console.WriteLine(reader.ReadLine());
                            if (nMessageCount-- < 0)
                                break;
                        }
                    }
                    Console.WriteLine("Never gets here!!!");
                }
            }
            Console.WriteLine("Done - press a key to exit");
            Console.ReadLine();
        }
