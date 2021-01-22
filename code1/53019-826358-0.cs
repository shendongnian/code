    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    private TcpListener tcpListener;
    private Thread listenerThread;
    volatile bool listening;
    // Create a client struct/class to handle connection information and names
    private List<Client> clients;
    // In constructor
    clients = new List<Client>();
    tcpListener = new TcpListener(IPAddress.Any, 3000);
    listening = true;
    listenerThread = new Thread(new ThreadStart(ListenForClients));
    listenerThread.Start();
    // ListenForClients function
    private void ListenForClients()
    {
        // Start the TCP listener
        this.tcpListener.Start();
        TcpClient tcpClient;
        while (listening)
        {
            try
            {
                // Suspends while loop till a client connects
                tcpClient = this.tcpListener.AcceptTcpClient();
                // Create a thread to handle communication with client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleMessage));
                clientThread.Start(tcpClient);
            }
            catch { // Handle errors }
        }
    }
    // Handling messages (Connect? Disconnect? You can customize!)
    private void HandleMessage(object client)
    {
        // Retrieve our client and initialize the network stream
        TcpClient tcpClient = (TcpClient)client;
        NetworkStream clientStream = tcpClient.GetStream();
        // Create our data
        byte[] byteMessage = new byte[4096];
        int bytesRead;
        string message;
        string[] data;
        // Set our encoder
        ASCIIEncoding encoder = new ASCIIEncoding();
        while (true)
        {
            // Retrieve the clients message
            bytesRead = 0;
            try { bytesRead = clientStream.Read(byteMessage, 0, 4096); }
            catch { break; }
            // Client had disconnected
            if (bytesRead == 0)
                break;
            // Decode the clients message
            message = encoder.GetString(byteMessage, 0, bytesRead);
            // Handle the message...
        }
    }
