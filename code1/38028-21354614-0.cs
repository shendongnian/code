    using (var webClient = new WebClient())
    using (var stream = webClient.OpenRead(streamingUri))
    {
         if (stream != null)
         {
              stream.ReadTimeout = Timeout.Infinite;
              using (var reader = new StreamReader(stream, Encoding.UTF8, false))
              {
                   string line;
                   while ((line = reader.ReadLine()) != null)
                   {
                        if (line != String.Empty)
                        {
                            Console.WriteLine("Count {0}", count++);
                        }
                        Console.WriteLine(line);
                   }
              }
         }
    }
