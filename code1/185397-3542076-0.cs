    public void Send(byte[] data)
            {
                try
                {
                    using (NetworkStream s = Client.GetStream())
                    {
                        using (BinaryWriter w = new BinaryWriter(s))
                        {
                            var buffer = m_coder.Encode(data);
                            w.Write(buffer);
                            w.Flush();
                        }
                    }
    
                }
                catch
                { handle_connection_lost(new ConnectionLostArgs(Id)); }
            }
