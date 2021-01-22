    private void connectAsync_Click(object sender, System.EventArgs e)
                    {
                            m_rapi.RAPIConnected += new RAPIConnectedHandler(m_rapi_RAPIConnected);
                            m_rapi.RAPIDisconnected += new RAPIConnectedHandler(m_rapi_RAPIDisconnected);
                            m_rapi.Connect(false, -1);
                    }
     
                    private void m_rapi_RAPIConnected()
                    {
                this.Invoke(textUpdate, new object[] { this, new TextArgs(connectStatus, "Connected") });
                this.Invoke(enableUpdate, new object[] { this, new EnableArgs(connectAsync, false) });
                this.Invoke(enableUpdate, new object[] { this, new EnableArgs(connectSync, false) });
                    }
     
                    private void m_rapi_RAPIDisconnected()
                    {
                this.Invoke(textUpdate, new object[] { this, new TextArgs(connectStatus, "Not Connected") });
                this.Invoke(enableUpdate, new object[] { this, new EnableArgs(connectAsync, false) });
                this.Invoke(enableUpdate, new object[] { this, new EnableArgs(connectAsync, false) });
                    }
    
     
    
                     private void copyFrom_Click(object sender, System.EventArgs e)
    
                    {
                            if(! m_rapi.Connected)
                            {
                                    MessageBox.Show("Not connected!");
                                    return;
                            }
     
                            m_rapi.CopyFileFromDevice("f:\\1.jpg", "\\My Documents\\1.jpg", true);
     
                    }
 
