    string output = textBox1.Text;
        
    textBox2.Text = string.Empty;
        
    foreach (char c in output)
    {
        int i = Convert.ToInt32(c);
        string r = Convert.ToString(i);
        textBox2.Text += r;
    }
