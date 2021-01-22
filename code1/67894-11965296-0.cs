    private bool CheckConnectivityForProxyHost(string hostName, int port)
           {
               if (string.IsNullOrEmpty(hostName))
                   return false;
    
               bool isUp = false;
               Socket testSocket = null;
    
               try
               {
    
                   testSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                   IPAddress ip = null;
                   if (testSocket != null && NetworkingCollaboratorBase.GetResolvedConnecionIPAddress(hostName, out ip))//Use a method to resolve your IP
                   {
                       IPEndPoint ipEndPoint = new IPEndPoint(ip, port);
    
                       isUp = false;
    //time out 5 Sec
                      CallWithTimeout(ConnectToProxyServers, 5000, testSocket, ipEndPoint);
                       
                           if (testSocket != null && testSocket.Connected)
                           {
                               isUp = true;
                           }
                       }
                    
                   }
               }
               catch (Exception ex)
               {
                   isUp = false;
               }
               finally
               {
                   try
                   {
                       if (testSocket != null)
                       {
                           testSocket.Shutdown(SocketShutdown.Both);
                       }
                   }
                   catch (Exception ex)
                   {
    
                   }
                   finally
                   {
                       if (testSocket != null)
                           testSocket.Close();
                   }
    
               }
    
               return isUp;
           }
    
    
     private void CallWithTimeout(Action<Socket, IPEndPoint> action, int timeoutMilliseconds, Socket socket, IPEndPoint ipendPoint)
           {
               try
               {
                   Action wrappedAction = () =>
                   {
                       action(socket, ipendPoint);
                   };
    
                   IAsyncResult result = wrappedAction.BeginInvoke(null, null);
    
                   if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
                   {
                       wrappedAction.EndInvoke(result);
                   }
                 
               }
               catch (Exception ex)
               {
                   
               }
           }
    
      private void ConnectToProxyServers(Socket testSocket, IPEndPoint ipEndPoint)
           {
               try
               {
                   if (testSocket == null || ipEndPoint == null)
                       return;
    
                       testSocket.Connect(ipEndPoint);
    
               }
               catch (Exception ex)
               {
                  
               }
           } 
