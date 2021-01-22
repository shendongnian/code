    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Net.Sockets;
    using System.Threading;
    namespace ConsoleApplication1 {
        class XMLBlaster {
            Thread myThread;
            public XMLBlaster() {
                myThread = new Thread(Start);
            }
            public void Begin() {
                myThread.Start();
            }
            //This will listen for a connection on port 12345, and send a tiny XML document
            //to the first person to connect.
            protected void Start() {
                TcpListener tcp = new TcpListener(IPAddress.Any, 12345);
                tcp.Start(1);
                TcpClient client = tcp.AcceptTcpClient();
                
                StreamWriter data = new StreamWriter(client.GetStream());
                data.Write("<myxmldocument><node1><node2></node2></node1></myxmldocument>");
                data.Close();
                client.Close();
            }
        }
        class Program {
            
            static void Main(string[] args) {
                //this sets up the server we will be reading
                XMLBlaster server = new XMLBlaster();
                server.Begin();
                //this is the important bit
                //First, create the client
                TcpClient tcp = new TcpClient(AddressFamily.InterNetwork);
                //Next, connect to the server. You probably will want to use the prober settings here
                tcp.Connect(IPAddress.Loopback, 12345);
                //Since byte manipulation is ugly, let's turn it into strings
                StreamReader data_in = new StreamReader(tcp.GetStream());
                //And, just read everything the server has to say
                Console.WriteLine(data_in.ReadToEnd());
                //when we're done, close up shop.
                data_in.Close();
                tcp.Close();
                //this is just to pause the console so you can see what's going on.
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(false);
            }
        }
    }
