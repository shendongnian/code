    public void SetStatusLabelText(string text)
    {
    	if (this.InvokeRequired)
    	{
    		this.Invoke((MethodInvoker) delegate
    		{
    			label1.Text = text;
    		});
    	}
    }
    public void SetDialogResult(DialogResult dialogResult)
    {
    	if (this.InvokeRequired)
    	{
    		this.Invoke((MethodInvoker)delegate
    		{
    			if (DialogResult == DialogResult.None)
    				this.DialogResult = dialogResult;
    		});
    	}
    }
