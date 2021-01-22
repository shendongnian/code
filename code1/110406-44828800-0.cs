    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace SingletonConsoleApp
    {
        class Program 
        {
            const string InterprocessID = "{D2D6725E-79C3-4988-8475-4446549B6E6D}"; // can be anything that's unique
            static Mutex appSingletonMaker = new Mutex(true, InterprocessID);
    
            static void Main(string[] args)
            {
                if (appSingletonMaker.WaitOne(TimeSpan.Zero, true))
                {
                    var argHandler = new Action<string[]>((arguments =>
                    {
                        Console.WriteLine(String.Join(" ", arguments));
                    }));
                    Task.Run(() =>
                    {
                        using (var server = new NamedPipeServerStream(InterprocessID))
                        {
                            using (var reader = new StreamReader(server))
                            {
                                using (var writer = new StreamWriter(server))
                                {
                                    while (true)
                                    {
                                        server.WaitForConnection();
                                        var incomingArgs = reader.ReadLine().Split('\t');
                                        writer.WriteLine("done");
                                        writer.Flush();
                                        server.Disconnect();
                                        argHandler(incomingArgs);
                                    }
                                }
                            }
                        }
                    });
                    argHandler(args);
                    Console.ReadKey();
                    appSingletonMaker.ReleaseMutex();
                }
                else
                {
                    if (args.Length > 0)
                    {
                        using (var client = new NamedPipeClientStream(InterprocessID))
                        {
                            client.Connect();
                            var writer = new StreamWriter(client);
                            using (var reader = new StreamReader(client))
                            {
                                writer.WriteLine(String.Join("\t", args));
                                writer.Flush();
                                reader.ReadLine();
                            }
                        }
                    }
                }
            }
        }
    }
