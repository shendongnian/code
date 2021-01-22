    while (connection.Available > 0)
            {
                int bytes = connection.Receive(
                    serverBuffer,
                    serverBuffer.Length,
                    0);
                message += Encoding.UTF8.GetString(
                    serverBuffer,
                    0,
                    bytes);
            }
