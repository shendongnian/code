    private void Form1_Load(object sender, EventArgs e)
    {
        GetDisk();
        tvFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(tvFolder_AfterSelect);
    }
    //...
    private void tvFolder_AfterSelect(object sender, TreeViewEventArgs e)
    {
        GetFile(e.Node.Text);
    }
