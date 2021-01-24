    void textBox1_Enter(object sender, System.EventArgs e)
	{
		textBox1.BackColor = Color.Yellow;
		textBox2.BackColor = Color.Gray;
	}
	void textBox2_Enter(object sender, System.EventArgs e)
	{
		textBox1.BackColor = Color.Gray;
		textBox2.BackColor = Color.Yellow;
	}
