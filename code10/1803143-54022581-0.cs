    using System;
    using System.Text;
    using System.Net.Sockets;
    using System.Collections.Generic;
    using WebSocketSharp;
    namespace Application1
    {
        class Program
        {
            static void Main(string[] args)
            {
            
                // Locals
                string host         = "127.0.0.1";
                int port            = 8080;
                int Frq_Reconnect   = 10000;
                WebSocket ws;
                // Start WebSocket Client
                ws              = new WebSocket(string.Format("ws://{0}:{1}", host, port));
                ws.OnOpen       += new EventHandler(ws_OnOpen);
                ws.OnMessage    += new EventHandler<MessageEventArgs>(ws_OnMessage);
                ws.OnError      += new EventHandler<ErrorEventArgs>(ws_OnError);
                ws.OnClose      += new EventHandler<CloseEventArgs>(ws_OnClose);
                // Connection loop
                while (true)
                {
                    try
                    {
                        if (!ws.IsAlive)
                        {
                            ws.Connect();
                            if (ws.IsAlive)
                            {
                                ws.Send(JsonConvert.SerializeObject(json, Formatting.None));
                            }
                            else
                            {
                                Console.WriteLine(string.Format("Attempting to reconnect in {0} s", Frq_Reconnect / 1000));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string errMsg = e.Message.ToString();
                        if (errMsg.Equals("The current state of the connection is not Open."))
                        {// remote host does not exist
                            Console.WriteLine(string.Format("Failed to connect to {0}:{1}", host, port));
                        }
                        if (errMsg.Equals("A series of reconnecting has failed."))
                        {// refusal of ws object to reconnect; create new ws-object
                            ws.Close();
                            ws             = new WebSocket(string.Format("ws://{0}:{1}", host, port));
                            ws.OnOpen     += new EventHandler(ws_OnOpen);
                            ws.OnMessage  += new EventHandler<MessageEventArgs>(ws_OnMessage);
                            ws.OnError    += new EventHandler<ErrorEventArgs>(ws_OnError);
                            ws.OnClose    += new EventHandler<CloseEventArgs>(ws_OnClose);
                        }
                        else
                        {// any other exception
                            Console.WriteLine(e.ToString());
                        }
                    
                    }
                // Callback handlers
                void ws_OnClose(object sender, CloseEventArgs e)
                {
                    Console.WriteLine("Closed for: " + e.Reason);
                }
                void ws_OnError(object sender, ErrorEventArgs e)
                {
                    Console.WriteLine("Errored");
                }
                void ws_OnMessage(object sender, MessageEventArgs e)
                {
                    Console.WriteLine("Messaged: " + e.Data);
                }
                void ws_OnOpen(object sender, EventArgs e)
                {
                    Console.WriteLine("Opened");
                }
            }// end      static void Main(...)
        }
    }
