     while (!connected)
            {
                try
                {
                    sock.Connect(authenServerEP);
                    connected = true;
                    establishingConnectionForm.Dispose();
                 }
                 catch (SocketException retryConnectException)
                 {
                     //Optional - add some wait time may be 5 seconds i.e. "trying again in 5 seconds"
                     //System.Threading.Thread.Sleep(5000);
                     //Here check the number of attempts and if exceeded:
                     if(numberOfTimes == 5)
                          break;
                     else{
                          numberOfTimes++; 
                          continue;
                     }
                 }
             }
