    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    namespace ConsoleApplication48
    {
        class Program
        {
            public class StateObject {  
                // Client socket.  
                public Socket workSocket = null;  
                // Size of receive buffer.  
                public const int BufferSize = 256;  
                // Receive buffer.  
                public byte[] buffer = new byte[BufferSize];  
                // Received data string.  
                public StringBuilder sb = new StringBuilder(); 
            }
            public class AsynchronousClient
            {
                // The port number for the remote device.  
                private const int port = 1200;
                // ManualResetEvent instances signal completion.  
                private static ManualResetEvent connectDone =
                    new ManualResetEvent(false);
                private static ManualResetEvent sendDone =
                    new ManualResetEvent(false);
                private static ManualResetEvent receiveDone =
                    new ManualResetEvent(false);
                // The response from the remote device.  
                private static String response = String.Empty;
                private static void StartClient()
                {
                    // Connect to a remote device.  
                    try
                    {
                        string LocalHostName = Dns.GetHostName();
                        IPHostEntry LocalHostIPEntry = Dns.GetHostEntry(LocalHostName); ;
                        IPAddress ipAddress = LocalHostIPEntry.AddressList.Where(x => !x.IsIPv6LinkLocal).FirstOrDefault();
                        IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                        // Create a TCP/IP socket.  
                        Socket client = new Socket(ipAddress.AddressFamily,
                            SocketType.Stream, ProtocolType.Tcp);
                        // Connect to the remote endpoint.  
                        client.BeginConnect(remoteEP,
                            new AsyncCallback(ConnectCallback), client);
                        connectDone.WaitOne();
                        // Send data to the remote device.  
                        Send(client, "HELLO");
                        sendDone.WaitOne();
                        while (true)
                        {
                            Receive(client);
                            receiveDone.WaitOne();
                            if (!string.IsNullOrWhiteSpace(response))
                                Console.WriteLine(response);
                        }
                        // Release the socket.  
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                private static void ConnectCallback(IAsyncResult ar)
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;
                    // Complete the connection.  
                    client.EndConnect(ar);
                    Console.WriteLine("Socket connected to {0}",
                        client.RemoteEndPoint.ToString());
                    // Signal that the connection has been made.  
                    connectDone.Set();
                }
                private static void Receive(Socket client)
                {
                    // Create the state object.  
                    StateObject state = new StateObject();
                    state.workSocket = client;
                    // Begin receiving the data from the remote device.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                private static void ReceiveCallback(IAsyncResult ar)
                {
                    // Retrieve the state object and the client socket   
                    // from the asynchronous state object.  
                    StateObject state = (StateObject)ar.AsyncState;
                    Socket client = state.workSocket;
                    // Read data from the remote device.  
                    int bytesRead = client.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.  
                        state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                        Send(client, "HELLO");
                        // Get the rest of the data.  
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                    else
                    {
                        // All the data has arrived; put it in response.  
                        if (state.sb.Length > 1)
                        {
                            response = state.sb.ToString();
                        }
                        // Signal that all bytes have been received.  
                        receiveDone.Set();
                    }
                }
                private static void Send(Socket client, String data)
                {
                    // Convert the string data to byte data using ASCII encoding.  
                    byte[] byteData = Encoding.ASCII.GetBytes(data);
                    // Begin sending the data to the remote device.  
                    client.BeginSend(byteData, 0, byteData.Length, 0,
                        new AsyncCallback(SendCallback), client);
                }
                private static void SendCallback(IAsyncResult ar)
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;
                    // Complete sending the data to the remote device.  
                    int bytesSent = client.EndSend(ar);
                    Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                    // Signal that all bytes have been sent.  
                    sendDone.Set();
                }
                public static void AcceptCallback(IAsyncResult ar) {  
                    // Signal the main thread to continue.  
                    // Get the socket that handles the client request.  
                    TcpListener  listener = (TcpListener) ar.AsyncState;  
                    Socket handler = listener.Server.EndAccept(ar);  
                    // Create the state object.  
                    StateObject state = new StateObject();  
                    state.workSocket = handler;  
                    handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,  
                        new AsyncCallback(ListenerReadCallback), state);  
                }  
                public static void ListenerReadCallback(IAsyncResult ar) {  
                    String content = String.Empty;  
                    // Retrieve the state object and the handler socket  
                    // from the asynchronous state object.  
                    StateObject state = (StateObject) ar.AsyncState;  
                    Socket handler = state.workSocket;  
                    // Read data from the client socket.   
                    int bytesRead = handler.EndReceive(ar);  
                    if (bytesRead > 0) {  
                    
                            handler.BeginSend(state.buffer, 0, bytesRead, 0,  
                               new AsyncCallback(ListenerSendCallback), handler);  
                    } 
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,  
                    new AsyncCallback(ListenerReadCallback), state);    
                }
                private static void ListenerSendCallback(IAsyncResult ar) {
                    Socket handler = (Socket)ar.AsyncState; 
                    int bytesSent = handler.EndSend(ar);  
                }
                static void Main(string[] args)
                {
                    TcpListener listener = new TcpListener(IPAddress.Any, 1200);
                    listener.Start();
                    listener.Server.BeginAccept(   
                        new AsyncCallback(AcceptCallback),  
                        listener );
                    StartClient();
                }
            }
        }
    }
