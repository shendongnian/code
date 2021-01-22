    public class Program
    {
        public static void Main()
        {
            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential("username", "password");
                client.OpenReadCompleted += (sender, e) =>
                {
                    using (var reader = new StreamReader(e.Result))
                    {
                        while (!reader.EndOfStream)
                        {
                            // TODO: feed this to your favorite JSON parser
                            Console.WriteLine(reader.ReadLine());
                        }
                    }
                };
                client.OpenReadAsync(new Uri("http://stream.twitter.com/1/statuses/filter.json?track=soccer,twitter"));
            }
            Console.ReadLine();
        }
    }
