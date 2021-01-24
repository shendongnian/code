    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using Microsoft.Extensions.Logging;
    namespace socketTst {
    class Program {
        static ILoggerFactory loggerFactory = new LoggerFactory().AddConsole().AddDebug();
        static ILogger _logger;
        static AutoResetEvent finish = new AutoResetEvent(false);
        static String Hostname = "www.google.com";
        static int Port = 80;
        static int RetryCount = 0;
        static void ConnectCallback(IAsyncResult ar) {
            _logger.LogInformation($"## ConnectCallback entered");
            // Retrieve the socket from the state object.  
            Socket client = (Socket) ar.AsyncState;
            try {
                // Complete the connection.  
                client.EndConnect(ar);
                var s = new byte[] { 1 };
                client.Send(s);
                var buf = new byte[1024];
                var cnt = client.Receive(buf);
                _logger.LogInformation($"## Connection to server successful at {client.RemoteEndPoint}");
                if (cnt > 0) {
                    var returned = Encoding.UTF8.GetString(buf, 0, cnt);
                    _logger.LogInformation($"## Data returned: {returned}");
                    }
                else {
                    _logger.LogInformation($"## No data returned");
                    }
                finish.Set(); // signal end of program
                }
            catch (SocketException sockExcep) {
                _logger.LogInformation($"## Exception: {sockExcep.Message}");
                _logger.LogInformation("## Connection to server failed. Retrying...");
                // This is a bad idea.  You don't know what is wrong so retrying might not be useful.
                // What if this is an unknown host or some other error that isn't likely to be
                // resolved by a retry ???
                RetryCount++;
                if (RetryCount > 10) {
                    _logger.LogInformation("## Not able to reach host after 10 tries");
                    finish.Set(); // signal end of program
                    return; // give up
                    }
                Thread.Sleep(797); // wait a bit
                var dest = new DnsEndPoint(Hostname, Port);
                client.BeginConnect(dest, new AsyncCallback(ConnectCallback), client);
                }
            catch (Exception ex) {
                _logger.LogInformation($"## Exception: {ex.Message}");
                }
            _logger.LogInformation($"## ConnectCallback exited");
            }
        static void Main(string[] args) {
            _logger = loggerFactory.CreateLogger<Program>();
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Blocking = true;
            var dest = new DnsEndPoint(Hostname, Port);
            _logger.LogInformation($"Attempting connection to {dest.Host}:{dest.Port}");
            _logger.LogInformation($"Socket blocking: {client.Blocking}");
            _logger.LogInformation("Calling BeginConnect");
            var thd = client.BeginConnect(dest, new AsyncCallback(ConnectCallback), client);
            _logger.LogInformation("BeginConnect complete");
            _logger.LogInformation("Calling WaitOne");
            finish.WaitOne(); // don't let program end until connection is made
            _logger.LogInformation("WaitOne complete");
            client.Close();
            Thread.Sleep(25); // if you don't do this the program ends before all the log output can be written
            Console.WriteLine("Program complete");
            }
        }
    }
