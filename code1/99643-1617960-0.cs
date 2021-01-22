    mockTcpClient.Setup(x => x.Dispose());
    try 
    {
        using (var popClient = new PopClient(null, mockTcpClient.Object))
        {
        }
    }
    finally 
    {
        mockTcpClient.VerifyAll();
    }
