    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Windows.Data;
    
    namespace DemoServer.Models
    {
        public class Server
        {
            public TcpListener Listener { get; set; }
            public int Port { get; set; }
            public bool IsStarted { get; private set; }
            public List<Receiver> Receivers = new List<Receiver>();
    
            public Server(int port)
            {
                Receivers.Clear();
                BindingOperations.EnableCollectionSynchronization(Receivers, Receivers);
                Port = port;
                IsStarted = false;
            }
    
            public void Start()
            {
                if (!IsStarted)
                {
                    try
                    {
                        Listener = new TcpListener(System.Net.IPAddress.Any, 0);
                        Listener.Start();
                        IsStarted = true;
                        IPAddress address = ((IPEndPoint)Listener.LocalEndpoint).Address;
                        int port = ((IPEndPoint) Listener.LocalEndpoint).Port;
                        Console.WriteLine("Server Started");
                        //Start Async pattern for accepting new connections
                        WaitForConnection();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        IsStarted = false;
                    }
                }
            }
    
            public void Stop()
            {
                if (IsStarted)
                {
                    Listener.Stop();
                    IsStarted = false;
                    Receivers.Clear();
                    Console.WriteLine("Server Stopped");
                }
            }
    
            private void WaitForConnection()
            {
                Listener.BeginAcceptTcpClient(new AsyncCallback(ConnectionHandler), null);
            }
    
            private void ConnectionHandler(IAsyncResult ar)
            {
                if (IsStarted)
                {
                    Receiver newClient = new Receiver(Listener.EndAcceptTcpClient(ar), this);
                    newClient.Start();
                    Receivers.Add(newClient);
                    WaitForConnection();
                }
            }
    
            public void SomeInteractionBetweenClients()
            {
                Console.WriteLine("Interaction!");
            }
        }
    }
