    using (NamedPipeClientStream namedPipeClient = new NamedPipeClientStream(".", "test-pipe", PipeDirection.InOut))
    {
        namedPipeClient.Connect();
        namedPipeClient.ReadMode = PipeTransmissionMode.Message;
        // StringBuilder is more efficient for string concatenation
        StringBuilder serverResponse = new StringBuilder();
        byte[] readBytes = new byte[5];
        do
        {
            // You need to store number of bytes read from pipe (to readCount variable).
            // It can be less then the length of readBytes buffer, in which case
            // GetString() would decode characters beyond end of message.
            var readCount = namedPipeClient.Read(readBytes, 0, readBytes.Length);
            var readText = Encoding.Default.GetString(readBytes, 0, readCount);
            // You original code "overwrites" content of serverResponse variable instead
            // of concatenating it to the previous value. So you would receive only 
            // the last part of the server message.
            serverResponse.Append(readText);
            // It is not needed to create new buffer, you can just reuse existing buffer
            //readBytes = new byte[5];
        // IsMessageComplete is now tested after read operation
        } while (!namedPipeClient.IsMessageComplete);
        System.Console.WriteLine(serverResponse.ToString());
        // You current server implementation exits as soon as it sends message to the client
        // and does not wait for incomming message. You'll have to change server accordingly 
        // to be able to send a message back to the server.
        //byte[] writeBytes = Encoding.Default.GetBytes("Hello from client!\n");
        //namedPipeClient.Write(writeBytes, 0, writeBytes.Length);
    }
