    public Form2 f2;
    private void button1_Click(object sender, EventArgs e)
    {
    	if (f2 == null)
    	{
    		f2 = new Form2 {f1 = this};
    		f2.Show();
    	}
    	else
    		f2.Focus();
    }
