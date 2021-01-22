    public Form1()
    {
        InitializeComponent();
        
        this.listBox1.DisplayMember = "Name";
        this.listBox1.ValueMember = "ID";
        
        this.listBox1.Items.Add(new Test(1, "A"));
        this.listBox1.Items.Add(new Test(2, "B"));
        this.listBox1.Items.Add(new Test(3, "C"));
        this.listBox1.Items.Add(new Test(4, "D"));
        this.listBox1.Items.Add(new Test(5, "E"));
    }
    
    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if(-1 != this.listBox1.SelectedIndex)
        {
            Test t = this.listBox1.Items[this.listBox1.SelectedIndex] as Test;
            if(null != t)
            {
                this.textBox1.Text = t.Name;
            }
        }
    }
