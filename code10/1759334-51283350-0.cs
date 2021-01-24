    private async void Button_Click(object sender, RoutedEventArgs e)
    {
            // generate a create socket task
            var createSocketTask = CreateSocket();
            
            // create 'do something else' task
            var doSomethingElseTask = DoSomethingElse();
            // run both tasks in parallel
            await Task.WhenAll(createSocketTask, doSomethingElseTask);
    }
    
    private async Task CreateSocket()
    {
        clientTcpSocket = new StreamSocket();
        try
        {// create the socket
            await clientTcpSocket.ConnectAsync(new HostName(ip), tcpPort);
            using (DataReader reader = new DataReader(clientTcpSocket.InputStream))
            {
                await reader.LoadAsync(sizeof(int));
                int fdToReadRcv = reader.ReadInt32();
                byte[] bs = BitConverter.GetBytes(fdToReadRcv);
                Array.Reverse(bs);
                int fdToRead = BitConverter.ToInt32(bs,0);
                Debug.WriteLine(fdToRead);
            }
            using (DataWriter writer = new DataWriter(clientTcpSocket.OutputStream))
            {
                writer.WriteString(String.Format("Client Start"));
                await writer.StoreAsync();
            }
            timer.Start();
            ListenTcpClient(clientTcpSocket);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
     private async Task DoSomethingElse()
     {
            // do something
     }
