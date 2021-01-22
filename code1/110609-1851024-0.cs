            using (TcpClient tcpClient = new TcpClient(strIP, 80))
            {
                using (Stream s = tcpClient.GetStream())
                {
                    byte[] bytesToSend = Encoding.ASCII.GetBytes("GET /\n");
                    s.Write(bytesToSend, 0, bytesToSend.Length);
                    int bytes;
                    byte[] buffer = new byte[4096];
                    do
                    {
                        bytes = s.Read(buffer, 0, buffer.Length);
                        Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytes));
                    } while (bytes > 0);
                }
            }
