    while (true)
    {
        if (stream.DataAvailable)
        {
            int count = stream.Read(bytes, i, bytes.Length);
            i += count;
            // ...add something to detect the end of message
        }
        else
        {
            Thread.Sleep(0);
        }
    }
