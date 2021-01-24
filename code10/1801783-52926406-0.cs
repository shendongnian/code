    public bool checkedthecheckbox { get; set; }
    CheckBox testchbox = new CheckBox();
    
    private void Form1_Load(object sender, EventArgs e)
    {
        testchbox.CheckedChanged += new EventHandler(testchbox_CheckedChanged);
    }
    
    void testchbox_CheckedChanged(object sender, EventArgs e)
    {
        if (testchbox.Checked)
            checkedthecheckbox = true;
        else
            checkedthecheckbox = false;
    }
