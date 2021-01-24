        private static void ReceiveByteAndRespond()
       {           
          using (NamedPipeClientStream namedPipeClient = new 
          NamedPipeClientStream("test-pipe"))
         {
        namedPipeClient.Connect();
        Console.WriteLine(namedPipeClient.ReadByte());
        namedPipeClient.WriteByte(2);
       }
    }
