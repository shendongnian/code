    //global property for storing the text value
    public string UserInput { get; set; }
    private void textBox1_TextChanged(object sender, EventArgs e)
	{
        UserInput = textBox1.Text;
	}
