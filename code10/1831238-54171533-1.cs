    bool mIsListening = false;
    TcpListener mTCPListener;
    private List<ClientNode> mlClientSocks;
    TcpClient tcpc;
    IPAddress IP;
    int Port;
    Thread t;
    public void StartServer(string _IP, int _Port)
    {
        IP = IPAddress.Parse(_IP);
        Port = _Port;
        t = new Thread(new ThreadStart(this.StartProcessing));
        t.Start();
    }
    public void StartProcessing()
    {
        //Server is started
        mlClientSocks = new List<ClientNode>();
        try
        {
            mTCPListener = new TcpListener(IP, Port);
            //Server is running now
            mTCPListener.Start();
            mIsListening = true;
            mTCPListener.BeginAcceptTcpClient(onCompleteAcceptTcpClient, mTCPListener);
        }
        catch (Exception exx)
        {
            // Handle exception message hare
        }
    }
    void onCompleteAcceptTcpClient(IAsyncResult iar)
    {
        TcpListener tcpl = (TcpListener)iar.AsyncState;
        TcpClient tclient = null;
        ClientNode cNode = null;
        if (!mIsListening)
        {
            //Stopped listening for incoming connections
            return;
        }
        try
        {
            tclient = tcpl.EndAcceptTcpClient(iar);
            //Client Connected...
            StreamReader sR = new StreamReader(tclient.GetStream());
            // Read the username (waiting for the client to use WriteLine())
            String username = (String)sR.ReadLine();
            tcpl.BeginAcceptTcpClient(onCompleteAcceptTcpClient, tcpl);
            
            lock (mlClientSocks)
            {
                // add newly connected client node in List
                mlClientSocks.Add((cNode = new ClientNode(
                    tclient,
                    new byte[512],
                    new byte[512],
                    tclient.Client.RemoteEndPoint.ToString(),
                    username,
                )));
            }
            // broadcasting newly connected client to all other clients
            BroadcastClients("New client connected: " + username);
            tclient.GetStream().BeginRead(cNode.Rx, 0, cNode.Rx.Length, onCompleteReadFromTCPClientStream, tclient);
        }
        catch (Exception exc)
        {
            // handle exception here
        }
    }
    void onCompleteReadFromTCPClientStream(IAsyncResult iar)
    {
        int nCountReadBytes = 0;
        string strRecv;
        ClientNode cn = null;
        try
        {
            lock (mlClientSocks)
            {
                tcpc = (TcpClient)iar.AsyncState;
                
                // find client from list
                cn = mlClientSocks.Find(x => x.strId == tcpc.Client.RemoteEndPoint.ToString());
                // check if client is connected
                if (IsConnected)
                    nCountReadBytes = tcpc.GetStream().EndRead(iar);
                else
                    nCountReadBytes = 0;
                
                //Disconnect Client if there is no byte
                if (nCountReadBytes == 0)
                {
                    mlClientSocks.Remove(cn);
                    return;
                }
                // read message recieved from client (node)
                strRecv = Encoding.ASCII.GetString(cn.Rx, 0, nCountReadBytes).Trim();
                /*
                
                  Handle messages from clients
                
                */
                cn.Rx = new byte[512];
                tcpc.GetStream().BeginRead(cn.Rx, 0, cn.Rx.Length, onCompleteReadFromTCPClientStream, tcpc);
                
            }
        }
        catch (Exception)
        {
            lock (mlClientSocks)
            {
                //Client is Disconnected and removed from list
                mlClientSocks.Remove(cn);
            }
        }
    }
    private void onCompleteWriteToClientStream(IAsyncResult iar)
    {
        try
        {
            TcpClient tcpc = (TcpClient)iar.AsyncState;
            tcpc.GetStream().EndWrite(iar);
        }
        catch (Exception exc)
        {
            // handle exception
        }
    }
    public void StopServer()
    {
        StopListing();
    }
    public void StopListing()
    {
        // stop server thread
        t.Interrupt();
        try
        {
            mIsListening = false;
            mTCPListener.Stop();
        }
        catch (Exception eee)
        {
            // handle exception
        }
    }
    public bool IsConnected
    {
        get
        {
            try
            {
                if (tcpc != null && tcpc.Client != null && tcpc.Client.Connected)
                {
                    // Detect if client disconnected
                    if (tcpc.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (tcpc.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            // Client disconnected
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
