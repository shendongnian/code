    byte[] message = new byte[4096];
    int bytesRead=0;
    while (true)
    {
        bytesRead = 0;
        try
        {
            bytesRead = clientStream.Read(message, 0, 4096);
        }
        catch
        {
            break;
        }
        if (bytesRead == 0)
        {
            break;
        }
        //message has successfully been received
        ASCIIEncoding encoder = new ASCIIEncoding();
        string msg = encoder.GetString(message, 0, bytesRead);
        if (!string.IsNullOrEmpty(msg.Replace("\r\n", "")))
        {
            int q = -1;
            if (int.TryParse(msg, out q))
            {
                queue.Enqueue(q);
            }
        }
    }
