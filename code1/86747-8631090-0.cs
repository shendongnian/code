    private void timer1_Tick(object sender, EventArgs e)
        {
            if (client.Client.Poll(0, SelectMode.SelectRead))
                {
                    if (!client.Connected) sConnected = false;
                    else
                    {
                        byte[] b = new byte[1];
                        try
                        {
                            if (client.Client.Receive(b, SocketFlags.Peek) == 0)
                            {
                                // Client disconnected
                                sConnected = false;
                            }
                        }
                        catch { sConnected = false; }
                    }
                }
            if (!sConnected)
            {
              //--Basically what you want to do afterwards
                timer1.Stop();
                client.Close();
                ReConnect();
            }
            
        }
