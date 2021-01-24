    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        var dataLength = serialPort1.BytesToRead;
        var data = new byte[dataLength];
        var nbrDataRead = serialPort1.Read(data, 0, dataLength);
    
        if (nbrDataRead == 0)
            return;
        Label1.Text = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
    }
