    private bool dateChanged;
    protected override void OnLoad(EventArgs e)
    {
    	base.OnLoad(e);
    	dateChanged = false;
    	button1.Enabled = false;
    }
    
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
    	dateChanged = true;
    	SetEnabledness();
    }
    
    private void SetEnabledness()
    {
    	button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) && dateChanged;
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    	SetEnabledness();
    }
