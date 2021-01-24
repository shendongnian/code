    private static void SendByteAndReceiveResponse()
     {           
         using (NamedPipeServerStream namedPipeServer = new 
          NamedPipeServerStream("test-pipe"))
         {
        namedPipeServer.WaitForConnection();
        namedPipeServer.WriteByte(1);
        int byteFromClient = namedPipeServer.ReadByte();
        Console.WriteLine(byteFromClient);
      }
    }
