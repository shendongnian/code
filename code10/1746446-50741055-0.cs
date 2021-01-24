    public void button1_MouseDown(object sender, EventArgs e)
    {
        textBox1.PasswordChar = '\0';
        textBox1.UseSystemPasswordChar = false;
    }
    public void button1_MouseUp(object sender, EventArgs e)
    {
        textBox1.PasswordChar = '*';
        textBox1.UseSystemPasswordChar = true;
    }
