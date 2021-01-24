    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    namespace TCPClientTest
    {
        class SyslogMessage
        {
            public Guid Guid = Guid.NewGuid();
            public byte[] MessageData;
        }
        class Program
        {
            static readonly int TCP_PORT = 1337;
            static byte[] SendTCPMessage(String hostname, int port, byte[] data)
            {
                using (var client = new TcpClient(hostname, port))
                {
                    using (var stream = client.GetStream())
                    {
                        stream.Write(data, 0, data.Length);
                        var responseData = new byte[1024];
                        var byteCount = stream.Read(responseData, 0, responseData.Length);
                        return responseData.Take(byteCount).ToArray();
                    }
                }
            }
            static void SendSyslog(String hostname, int port, SyslogMessage m)
            {
                SendTCPMessage(hostname, port, m.MessageData);
            }
            static Queue<SyslogMessage> sysLogQueue = new Queue<SyslogMessage>(new List<SyslogMessage>()
            { 
                new SyslogMessage() { MessageData = Encoding.UTF8.GetBytes("Test data 1")},
                new SyslogMessage() { MessageData = Encoding.UTF8.GetBytes("Test data 2")}
            });
            static void Main(string[] args)
            {
                System.Threading.Timer timer = new System.Threading.Timer(SendLogs, null, 1000, 5000);
                Console.WriteLine("Press return to continue...");
                Console.Read();
            }
            static void SendLogs(object state)
            {
                while (sysLogQueue.Count > 0)
                {
                    try
                    {
                        var m = sysLogQueue.Peek();
                        SendSyslog("localhost", TCP_PORT, m);
                        Console.WriteLine("Sent sys log: " + Encoding.UTF8.GetString(m.MessageData));
                        // Remove from queue.
                        sysLogQueue.Dequeue();
                    }
                    catch (SocketException e)
                    {
                        // Leave in the queue.
                        Console.WriteLine("Failed to send log: Socket exception occurred: {0}", e);
                        // Break until next attempt.
                        break;
                    }
                }
            }
        }
    }
