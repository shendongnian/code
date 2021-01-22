    public Form1()
    {
        InitializeComponent();
        this.tabControl1.MouseClick += new MouseEventHandler(tabControl1_MouseClick);
    }
    private void tabControl1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            this.contextMenuStrip1.Show(this.tabControl1, e.Location);
        }
        
    }
