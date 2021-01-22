    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Threading;
    namespace MutexApp
    {
        class Program
        {
            private const string PIPE_NAME = "MY_PIPE"; // Name of pipe
            private const string MUTEX_NAME = "MY_MUTEX"; // Mutex name
            static void Main(string[] args)
            {
                string message = "NO MESSAGE";
                if (args.Length > 0) // If we have a parameter to the .exe get it
                    message = args[0];
                bool firstinstance = false;
                Mutex mutex = new Mutex(true, MUTEX_NAME, out firstinstance);
                if (firstinstance) // We are the first instance of this process
                {
                    Console.WriteLine("First instance started");
                    Console.WriteLine("Message: " + message);
                    Console.WriteLine("Waiting for messages (ctrl+c to break)...");
                    while (true) { ProcessNextClient(); } // Unfinite loop that listens for messages by new clients
                }
                else // This process is already running, parse message to the running instance and exit
                {
                    {
                        try
                        {
                            using (NamedPipeClientStream client = new NamedPipeClientStream(PIPE_NAME)) // Create connection to pipe
                            {
                                client.Connect(5000); // Maximum wait 5 seconds
                                using (StreamWriter writer = new StreamWriter(client))
                                {
                                    writer.WriteLine(message); // Write command line parameter to the first instance
                                }
                            }
                        } catch (Exception ex)
                        {
                            Console.WriteLine("Error: "+ex.Message);
                        }
                    }
                }
                mutex.Dispose();
            }
            private static void ProcessNextClient()
            {
                try
                {
                    NamedPipeServerStream pipeStream = new NamedPipeServerStream(PIPE_NAME, PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances); // Create Server pipe and listen for clients
                    pipeStream.WaitForConnection(); // Wait for client connection
                    using (StreamReader reader = new StreamReader(pipeStream)) // Read message from pipe stream
                    {
                        string message = reader.ReadLine();
                        Console.WriteLine("At " + DateTime.Now.ToLongTimeString()+": " + message); // Print message on screen
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
