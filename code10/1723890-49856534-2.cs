    public Form1()
    {
    	InitializeComponent();
    	checkBox2.Enabled = false;
    	checkBox1.CheckedChanged += (s, e) => checkBox2.Enabled = checkBox1.Checked;
    }
