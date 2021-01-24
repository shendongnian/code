        public static void SendBytesToClients(Byte[] broadcastBytes, Dictionary<string, TcpClient> receiverList)
        {
            foreach (var client in receiverList)
            {
                try
                {
                    TcpClient broadcastSocket = (TcpClient)client.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    ClientConnector.ClientsList.Remove(client.Key);
                }
            }
        }
