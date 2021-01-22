        public void SendMsg(string msg)
    {
        MessageHelper msgHelper = new MessageHelper();
    	int hWnd = msg.getWindowId(null, "The title of the form you want to send a message to");
    	int result = msg.sendWindowsStringMessage(hWnd, 0, msg)
    	//Or for an integer message
    	result = msg.sendWindowsMessage(hWnd, MessageHelper.WM_USER, 123, 456);
    }
    
    //In your form window where you want to receive the message
    
    protected override void WndProc(ref Message m)
    {
    	switch (m.Msg)
    	{
    		case MessageHelper.WM_USER:
    			MessageBox.Show("Message recieved: " + m.WParam + " - " + m.LParam);
    			break;
    		case MessageHelper.WM_COPYDATA:
    			MessageHelper.COPYDATASTRUCT mystr = new MessageHelper.COPYDATASTRUCT();
    			Type mytype = mystr.GetType();
    			mystr = (COPYDATASTRUCT)m.GetLParam(mytype);
    			MessageBox.Show(mystr.lpData);
    			break;
    	}
    	base.WndProc(ref m);
    }
