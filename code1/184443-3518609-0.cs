    networkStream = clientSocket.GetStream();
    int bytesReceived = networkStream.Read(
       bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
    dataFromClient = System.Text.Encoding.ASCII.GetString(
       bytesFrom, 0, bytesReceived);
