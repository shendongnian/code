    StringBuilder sb = new StringBuilder();
    char LF = (char)10;
    Queue<string> q = new Queue<string>();
    
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string Data = serialPort1.ReadExisting();
    
        foreach (char c in Data)
        {
            if (c == LF)
            {
                sb.Append(c);
    
                CurrentLine = sb.ToString();
                sb.Clear();
    
                q.Enqueue(currentLine);
            }
            else
            {
                sb.Append(c);
            }
        }
    }
    
    private void backgroundWorkerQ_DoWork(object sender, DoWorkEventArgs e)
    {
    	while (true)
    	{
    		if (backgroundWorkerQ.CancellationPending)
    			break;
    
    		if (q.Count > 0)
    		{
    			richTextBoxTerminal.AppendText(q.Dequeue());
    		}
    
    		Thread.Sleep(10);
    	}
    }
