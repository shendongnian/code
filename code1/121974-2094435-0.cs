    private void Form1_Load(object sender, EventArgs e)
    {
        button1.MouseWheel += new MouseEventHandler(button1_MouseWheel);
        button1.Select();  
    }
