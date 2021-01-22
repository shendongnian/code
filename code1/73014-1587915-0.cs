    private bool ShowMessageBoxYesNo()
    {
    	if (this.InvokeRequired)
    		return (bool)this.Invoke(new ShowMessageBoxYesNoDelegate(ShowMessageBoxYesNo));
    	else
    	{
    		DialogResult res = MessageBox.Show("What ?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    		if (res == DialogResult.Yes)
    			return true;
    		else 
    			return false;
    	}
    }
