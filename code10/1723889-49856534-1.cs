    public Form1()
    {
    	InitializeComponent();
    	checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
        checkBox2.Enabled = false;
    }
    
    //When happens some change in a checkBox1
    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
    	if (checkBox1.Checked)
    		checkBox2.Enabled = true;
    	else
    		checkBox2.Enabled = false;
    }
