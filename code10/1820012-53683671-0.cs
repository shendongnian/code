    private void button1_Click(object sender, EventArgs e)
    {
    	if(string.IsNullOrWhiteSpace(textBox1.Text)) return;
    	
    	if(textBox1.Text[0] == 'a')
    	{
    		textBox2.Text = "Error";
    		return;
    	}
    		
    	textBox2.Text = string.Join(" ", textBox1.Text.ToCharArray());
    }
