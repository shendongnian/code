      if (client.Client.Poll(0, SelectMode.SelectRead))
                        {
                            byte[] checkConn = new byte[1];
                            if (client.Client.Receive(checkConn, SocketFlags.Peek) == 0)
                            {
                                throw new IOException();
                            }
                        }
