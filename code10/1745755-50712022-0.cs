	private void textBox1_TextChanged(object sender, EventArgs e)
	{
        Calculate();
	}
	private void textBox2_TextChanged(object sender, EventArgs e)
	{
        Calculate();
	}    
	private void button1_Click(object sender, EventArgs e)
	{
        Calculate();
	}
	private void Calculate()
	{
		aantalgroep = int.Parse(textBox1.Text);
		/* Wat er gebeurd bij RadioButton1 Checked */
		if (radioButton1.Checked) {
			number = aantalgroep * 8;
			textBox2.Text = number.ToString();
			if (aantalgroep < 10) {
				textBox2.Text = number.ToString();
			}
		}
	}
