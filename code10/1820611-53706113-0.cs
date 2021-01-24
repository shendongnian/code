    Task.Run(() =>
                    {
                        while (true)
                        {                       
                            try
                            {
                                data = client.Receive(ref RemoteIpEndPoint);                            
                            }
                            catch (SocketException ex)
                            {
                                                                 
                                    MessageBox.Show("Cannot Find The Device.", "Device Error.");
                               
                            }  
                            catch (Exception e)
                            {
                                    MessageBox.Show(e.GetType().Name, e.Message);
                            }
                                                      
                        }
                    });
