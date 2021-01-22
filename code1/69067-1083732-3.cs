    using (var client = new WebClient())
    {
        client.Credentials = new NetworkCredential("username", "password");
        client.OpenReadCompleted += (sender, e) =>
        {
            using (var reader = new StreamReader(e.Result))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        };
        client.OpenReadAsync(new Uri("http://stream.twitter.com/spritzer.json"));
    }
    Console.ReadLine();
