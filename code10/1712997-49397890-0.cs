    using Clifton.Core.Pipes;
    using System;
    using System.Diagnostics;
    
    namespace NamedPipeTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                StartServer();
                Console.ReadLine();
            }
    
            private static void StartServer()
            {
                ServerPipe serverPipe = new ServerPipe("Test", p => p.StartByteReaderAsync());
                var sw = new Stopwatch();
    
                serverPipe.Connected += (s, ea) => {
                    Console.WriteLine("Server connected");
                    sw.Start();
                };
                serverPipe.DataReceived += (s, ea) => {
                    Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss.fff")}\t {sw.ElapsedMilliseconds}\t Data received. Length: {ea.Len}");
                    sw.Restart();
                };
            }
        }
    
