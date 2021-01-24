    while (true)
    {
        if (clientStream.DataAvailable)
                {
                    while ((i = clientStream.Read(bytesBuffer, 0, bytesBuffer.Length)) != 0)
                    {
                        memoryStream.Write(bytesBuffer, 0, bytesBuffer.Length);
                        if (clientStream.DataAvailable)
                            continue;
                        else
                            break;
                    }
                    Console.WriteLine("Received from server {0}", Encoding.ASCII.GetString(memoryStream.ToArray()));
                    break;
                }
                else
                {
                    continue;
                }
        }
