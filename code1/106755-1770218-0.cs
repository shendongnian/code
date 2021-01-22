    class Program
    {
        static void Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Loopback, 9999);
            listener.Start();
            while (true)
            {
                var client = listener.AcceptTcpClient();
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
