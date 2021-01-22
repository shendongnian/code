    private void button1_Click(object sender, System.EventArgs e)
    {
        textBox1.Text = "Hello World";
        textBox1.Select(6, 5);
        MessageBox.Show(textBox1.SelectedText);
    }
