        static void Main(string[] args)
        {
           var client = new SayHelloClient();
           Console.WriteLine(client.HelloAsync("dotnet-svcutil").Result);
        }
