    void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
       //this call delegate to display data
       UpdateTheUI(statusMsg);
    }
    private void UpdateTheUI(string statusMsg)
    {
        if (lblMsgResp.InvokeRequired)
        {
            lblMsgResp.BeginInvoke(new MethodInvoker(UpdateTheUI,statusMsg));
        }
        else
        {
           clsConnect(statusMsg);
        }
    }
