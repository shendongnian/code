    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead("http://www.google.com"))
            using (StreamReader reader = new StreamReader(stream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
