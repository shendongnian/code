    private void button1_Click(object sender, EventArgs e)
    {
        Form1.DoSomething(textBox1);
    }
    
    public static void DoSomething(TextBox textbox)
    {
        textbox.Text = DateTime.Now.ToString();
    }
