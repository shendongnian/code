    using Clifton.Core.Pipes;
    using System;
    
    namespace NamedPipeTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                StartClient(iterations: 100);
                Console.ReadLine();
            }
    
            private static void StartClient(int iterations)
            {
                ClientPipe clientPipe = new ClientPipe(".", "Test", p => p.StartByteReaderAsync());
                clientPipe.Connect();
    
                byte[] data = CreateRandomData(sizeMb: 4);
    
                for (int i = 0; i < iterations; i++)
                {
                    clientPipe.WriteBytes(data);
                    Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss.fff")}\t Wrote data {i}");
                }
            }
    
            private static byte[] CreateRandomData(int sizeMb)
            {
                var data = new byte[1024 * 1024 * sizeMb];
                new Random().NextBytes(data);
                return data;
            }
        }
    }
