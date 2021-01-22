    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
    	if (keyData == (Keys.Control | Keys.X))
    	{
    		DoSomething();
    		return true;
    	}
    	return base.ProcessCmdKey(ref msg, keyData);
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    	DoSomething();
    }
    
    private void DoSomething()
    {
    	MessageBox.Show("hi!");
    }
