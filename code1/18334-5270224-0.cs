    private void buttonStart_Click(object sender, EventArgs e)
    {
        port.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(port_ErrorReceived);
    }
    
    void port_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
    {
        // TODO: handle the problem here
    }
