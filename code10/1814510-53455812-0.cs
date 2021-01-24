            try
            {
                TcpClient client = new TcpClient(127.0.0.1, 6419);
                NetworkStream ns = client.GetStream();
                byte[] bytes = new byte[1024];
                int bytesRead = await ns.ReadAsync(bytes, 0, bytes.Length);
                string result = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                client.Close();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
