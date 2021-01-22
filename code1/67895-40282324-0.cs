    using System.Net.Sockets;
    using System.Threading;
    using System.Net;
    using System;
    using System.Diagnostics;
    
    class ConnexionParameter : Guardian
    {
        public TcpClient client;
        public string address;
        public int port;
        public Thread principale;
        public Thread thisthread = null;
        public int timeout;
    
        private EventWaitHandle wh = new AutoResetEvent(false);
    
        public ConnexionParameter(TcpClient client, string address, int port, int timeout, Thread principale)
        {
            this.client = client;
            this.address = address;
            this.port = port;
            this.principale = principale;
            this.timeout = timeout;
            thisthread = new Thread(Connect);
        }
    
      
        public void Connect()
        {
            WatchDog.Start(timeout, this);
            try
            {
                client.Connect(IPAddress.Parse(address), port);
    
            }
            catch (Exception)
            {
                UnityEngine.Debug.LogWarning("Unable to connect service (Training mode? Or not running?)");
            }
            OnTimeOver();
            //principale.Resume();
        }
    
        public bool IsConnected = true;
        public void OnTimeOver()
        {
            try
            {
                if (!client.Connected)
                {
                        /*there is the trick. The abort method from thread doesn't
     make the connection stop immediately(I think it's because it rise an exception
     that make time to stop). Instead I close the socket while it's trying to
     connect , that make the connection method return faster*/
                    IsConnected = false;
                    client.Close();
                }
                wh.Set();
    
            }
            catch(Exception)
            {
                UnityEngine.Debug.LogWarning("Connexion already closed, or forcing connexion thread to end. Ignore.");
            }
        }
    
    
        public void Start()
        {
            
            thisthread.Start();
            wh.WaitOne();
            //principale.Suspend();
        }
    
        public bool Get()
        {
            Start();
            return IsConnected;
        }
    }
    
    
    public static class Connexion
    {
    
    
        public static bool Connect(this TcpClient client, string address, int port, int timeout)
        {
            ConnexionParameter cp = new ConnexionParameter(client, address, port, timeout, Thread.CurrentThread);
            return cp.Get();
        }
    
    //http://stackoverflow.com/questions/19653588/timeout-at-acceptsocket
        public static Socket AcceptSocket(this TcpListener tcpListener, int timeoutms, int pollInterval = 10)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutms);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.Elapsed < timeout)
            {
                if (tcpListener.Pending())
                    return tcpListener.AcceptSocket();
    
                Thread.Sleep(pollInterval);
            }
            return null;
        }
    
    
    }
