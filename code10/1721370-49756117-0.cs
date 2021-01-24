    StreamWriter Writer = new StreamWriter(client.GetStream(), Encoding.ASCII);
    try {
        lock(allClients) { allClients.Add(Writer); }
        while (ClientConnected)
        {
            ...
        }
    } finally {
        lock(allClients) { allClients.Remove(Writer); }
    }
