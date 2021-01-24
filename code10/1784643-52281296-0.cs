    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
    	string Data = serialPort1.ReadExisting();
    
    	this.Invoke((MethodInvoker)delegate
    	{
    		textBox2.AppendText(Data);
    	});
    }
