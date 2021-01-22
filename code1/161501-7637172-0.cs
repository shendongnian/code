        const int BufferSize = 4096;
        Decoder decoder = Encoding.UTF8.GetDecoder();
        StringBuilder msg = new StringBuilder();
        char[] chars = new char[BufferSize];
        byte[] bytes = new byte[BufferSize];
        int numBytes = 0;
        MessageBox.Show("before do while loop");
        numBytes = pipeServer.Read(bytes, 0, BufferSize);
        if (numBytes > 0)
        {
            int numChars = decoder.GetCharCount(bytes, 0, numBytes);
            decoder.GetChars(bytes, 0, numBytes, chars, 0, false);
            msg.Append(chars, 0, numChars);
        }
        MessageBox.Show(numBytes.ToString() + " " + msg.ToString());
        MessageBox.Show("Finished reading, now starting writing");
        using (StreamWriter swr = new StreamWriter(pipeServer))
        {
            MessageBox.Show("Sending ok back");
            swr.WriteLine("OK");
            pipeServer.WaitForPipeDrain();
        }
