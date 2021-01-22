    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead("http://ws.audioscrobbler.com/2.0/?method=album.getinfo&api_key=b25b959554ed76058ac220b7b2e0a026&artist=Cher&album=Believe"))
            using (TextReader reader = new StreamReader(stream))
            {
                XDocument xdoc = XDocument.Load(reader);
                var summaries = from element in xdoc.Descendants()
                        where element.Name == "summary"
                        select element;
                foreach (var summary in summaries)
                {
                    Console.WriteLine(summary.Value);
                }
            }
        }
    }
