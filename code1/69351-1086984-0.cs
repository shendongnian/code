    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    using System.Threading;
    using System.Diagnostics;
    
    namespace stackoverflowtest
    {
        class Program
        {
    
            static private object oSyncRoot = new object();
    
            static private TcpListener oTCPListener;
    
            static private IPAddress oIPaddress = IPAddress.Parse("10.1.1.109");
    
            static private int nPort = 8009;
    
            static bool bIsListening = true;
    
            
    
    
    
            static void Main(string[] args)
            {
                StartListening();
                Thread.Sleep(500000);
                bIsListening = false;
            }
    
            public static void StartListening()
            {
                try
                {
                    lock (oSyncRoot)
                    {
                        oTCPListener = new TcpListener(oIPaddress, nPort);
    
                        // fire up the server
                        oTCPListener.Start();
    
                        // set listening bit
                        bIsListening = true;
                    }
    
                    // Enter the listening loop.
                    do
                    {
                        // Wait for connection
                        TcpClient newClient = oTCPListener.AcceptTcpClient();
    
                        
    
                        // queue a request to take care of the client
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessConnection), newClient);
                    }
                    while (bIsListening);
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException: " + se.ToString());
                }
                finally
                {
                    // shut it down
                    //StopListening();
                }
            }
    
            private static void ProcessConnection(object oClient)
            {
    
                TcpClient oTCPClient = (TcpClient)oClient;
                try
                {
                    byte[] abBuffer = new byte[1024];
                    StringBuilder sbReceivedData = new StringBuilder();
    
                    using (NetworkStream oNetworkStream = oTCPClient.GetStream())
                    {
                        int nInitialTimeoutMS = 1000;
                        // set initial read timeout to nInitialTimeoutMS to allow for connection
                        oNetworkStream.ReadTimeout = nInitialTimeoutMS;
    
                        int nBytesRead = 0;
    
                        do
                        {
                            try
                            {
                                bool bDataAvailable = oNetworkStream.DataAvailable;
                                Stopwatch sw = new Stopwatch();
                                while (!bDataAvailable)
                                {
                                    Thread.Sleep(5);
                                    bDataAvailable = oNetworkStream.DataAvailable;
                                }
                                Console.WriteLine("DataAvailable loop took " + sw.ElapsedMilliseconds);
    
                                sw.Reset();
                                nBytesRead = oNetworkStream.Read(abBuffer, 0, abBuffer.Length);
                                Console.WriteLine("Reading " + nBytesRead + " took " + sw.ElapsedMilliseconds);
                                if (nBytesRead > 0)
                                {
                                    // Translate data bytes to an ASCII string and append
                                    sbReceivedData.Append(Encoding.UTF8.GetString(abBuffer, 0, nBytesRead));
                                    // decrease read timeout to nReadTimeoutMS second now that data is coming in
                                    int nReadTimeoutMS = 100;
                                    oNetworkStream.ReadTimeout = nReadTimeoutMS;
    
                                }
                            }
                            catch (IOException)
                            {
                                // read timed out, all data has been retrieved
                                nBytesRead = 0;
                            }
                        }
                        while (nBytesRead > 0);
    
                        byte[] abResponse = new byte[1024];
                        for (int i = 0; i < abResponse.Length; i++)
                        {
                            abResponse[i] = (byte)i;
                        }
                        oNetworkStream.Write(abResponse, 0, abResponse.Length);
                        oNetworkStream.Flush();
    
                        //send the data to the callback and get the response back
                        //byte[] abResponse = oClientHandlerDelegate(sbReceivedData.ToString(), oTCPClient);
                        //if (abResponse != null)
                        //{
                        //    oNetworkStream.Write(abResponse, 0, abResponse.Length);
                        //    oNetworkStream.Flush();
                        //}
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Caught Exception " + e.StackTrace);
                }
                finally
                {
                    // stop talking to client
                    if (oTCPClient != null)
                    {
                        oTCPClient.Close();
                    }
                }
            }
    
        }
    }
