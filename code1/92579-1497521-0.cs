    public int Unit {get;set;}
    private void Form1_Load(object sender, EventArgs e)
    {
        textBox1.DataBindings.Add("Text", this, "Unit");
    }
