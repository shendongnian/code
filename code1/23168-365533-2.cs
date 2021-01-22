    while (listen){
         // Step 0: Client connection
         if (!listener.Pending())
         {
              Thread.Sleep(500); // choose a number (in milliseconds) that makes sense
              continue; // skip to next iteration of loop
         }
    
         TcpClient client = listener.AcceptTcpClient();
         Thread clientThread = new Thread(new ParameterizedThreadStart(HandleConnection));
         clientThread.Start(client.GetStream());
         client.Close();
    }
