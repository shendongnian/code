    protected override void WndProc(ref Message message)
    {
    	const int WM_SYSCOMMAND = 0x0112;
    	const int SC_MAXIMIZE = 0xF030; 
    
    	switch (message.Msg)
    	{
    		case WM_SYSCOMMAND:
    			int command = message.WParam.ToInt32() & 0xfff0;
    			if (command == SC_MAXIMIZE) 
    			{
    				this.maximize = true;
    				this.MaximumSize = new System.Drawing.Size(0, 0);
    			}
    			break;
    	}
    	
    	base.WndProc(ref message);
    }
    
    private void resize_form(object sender, EventArgs e)
    {
    	if (!maximize)
    	{
    		this.MaximumSize = new System.Drawing.Size(1000, this.panel4.Height + this.label2.Height + this.HeightMin);
    	}
    }
