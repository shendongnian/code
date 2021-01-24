    if(this.GeekPanel.InvokeRequired)
    {
    	this.GeekPanel.Invoke(new MethodInvoker(() =>
    	{
    		this.GeekPanel.Controls.Clear();
    		this.GeekPanel.Controls.Add(GeekOnComplete);
    	}));
    }
    else
    {
    	this.GeekPanel.Controls.Clear();
    	this.GeekPanel.Controls.Add(GeekOnComplete);
    }
