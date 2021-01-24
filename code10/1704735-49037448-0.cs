    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {   
                // not await for exploration
                var task = StartServer();
                
                Console.WriteLine("Main StartServer finished");
                task.Wait();
                Console.WriteLine("task.Wait() finished");
                Console.ReadKey();
            }        
    
            static async Task StartServer()
            {
                Console.WriteLine("StartServer enter");
    
                for(int i = 0; i < 3; i++) {
                    await Task.Delay(1000); // listener.AcceptTcpClientAsync simulation
                    SendHundredMessages();
                }
    
                Console.WriteLine("StartServer exit");
            }
    
            static async Task SendHundredMessages()
            {
                Console.WriteLine("SendHundredMessages enter");
    
                await Task.Run(() => {
                    Thread.Sleep(2000);
                });
    
                Console.WriteLine("SendHundredMessages exit");
            }        
        }
    }
