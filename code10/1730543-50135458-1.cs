    this.button1.Click += new System.EventHandler(this.button1_Click);
    this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
    this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
    this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
    private void button1_Click(object sender, EventArgs e)
    {
        Console.WriteLine("button1_Click");
    }
    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
        Console.WriteLine("button1_MouseClick");
    }
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        Console.WriteLine("button1_MouseDown");
    }
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
        Console.WriteLine("button1_MouseUp");
    }
