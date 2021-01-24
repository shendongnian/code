    private void button1_Click(object sender, EventArgs e)
    {
        string input = textBox1.Text;
        int shift = int.Parse(textBox2.Text);
        foreach(char c in input)
        {
            int inputInt = (int)c;
            int result = shift + inputInt;
            // result > 255?
            textBox3.Text += (char)result;
        }
    }
