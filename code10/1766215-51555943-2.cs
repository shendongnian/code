    using System;
    using WebSocketSharp;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var ws = new WebSocket("wss://api.bitfinex.com/ws/2"))
                {
                    ws.OnMessage += (sender, e) => Console.WriteLine(e.Data);
    
                    ws.Connect();
                    ws.Send("{\"event\":\"subscribe\", \"channel\":\"ticker\", \"pair\":\"BTCUSD\"}");
                    Console.ReadKey(true);
                }
            }
        }
    }
