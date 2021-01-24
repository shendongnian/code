	private void button2_Click(object sender, EventArgs e)
	{
		File.AppendAllText("metinbelgesi.txt", $"{textBox1.Text} {textBox2.Text} {textBox3.Text}.");
	}
	
	private void button3_Click(object sender, EventArgs e)
	{
		if (File.Exists("metinbelgesi.txt"))
		{
			richTextBox1.Text = File.ReadAllText("metinbelgesi.txt");
		}
		else
		{
			MessageBox.Show("First, You Join.");
		}
	}
