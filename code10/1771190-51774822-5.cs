    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
    	string data = serialPort1.ReadExisting();
    
    	//DataReceived event is on it's own thread, need to invoke to update the UI
    	this.Invoke((MethodInvoker)delegate
    	{
    		foreach (char c in data)
    		{
    			richTextBoxConsole.AppendText(c + "");
    
    			if (c == '\b')
    			{
    				//backspace, erase a char
    				richTextBoxConsole.Text = richTextBoxConsole.Text.Substring(0, richTextBoxConsole.Text.Length - 2);
    			}
    		}
    		
    		richTextBoxConsole.SelectionStart = richTextBoxConsole.Text.Length;
    		SendMessage(richTextBoxConsole.Handle, WM_VSCROLL, SB_BOTTOM, 0);
    	});
    }
