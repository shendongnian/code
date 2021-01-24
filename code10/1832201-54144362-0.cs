    if (IsConnected(client.tcp))
    {
        client.tcp.Close();
        client.tcp.Dispose(); //Dispose of a stream to release it for GC
        disconectedClients.Add(client);
        connectedClients.Remove(client); //Note to also remove the disconnected client from the connectedClients list.
        continue;
    }
    else
    { ...rest of logic }
