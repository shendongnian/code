    using System;
    using WebSocketSharp;
    namespace Example
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                using (var ws = new WebSocket("wss://stream.binance.com:9443"))
                {
                    ws.OnMessage += (sender, e) =>
                        Console.WriteLine("Message received" + e.Data);
    
                    ws.OnError += (sender, e) =>
                        Console.WriteLine("Error: " + e.Message);
                    
                    ws.Connect();
                    Console.ReadKey(true);
                }
            }
        }
    }
