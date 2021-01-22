    private string _selectedMenuItem;
    private readonly ContextMenuStrip collectionRoundMenuStrip;
    public Form1()
    { 
        var toolStripMenuItem1 = new ToolStripMenuItem {Text = "Copy CR Name"};
        toolStripMenuItem1.Click += toolStripMenuItem1_Click;
        var toolStripMenuItem2 = new ToolStripMenuItem {Text = "Get information on CR"};
        toolStripMenuItem2.Click += toolStripMenuItem2_Click;
        collectionRoundMenuStrip = new ContextMenuStrip();
        collectionRoundMenuStrip.Items.AddRange(new ToolStripItem[] {toolStripMenuItem1, toolStripMenuItem2 });
        listBoxCollectionRounds.MouseDown += listBoxCollectionRounds_MouseDown;
    }
    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        var info = GetInfoByName(_selectedMenuItem);
       MessageBox.Show(info.Name + Environment.NewLine + info.Date);
    }
    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(_selectedMenuItem);
    }
    private void myListBox_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        var index = myListBox.IndexFromPoint(e.Location);
        if (index != ListBox.NoMatches)
        {
            _selectedMenuItem = listBoxCollectionRounds.Items[index].ToString();
            collectionRoundMenuStrip.Show(Cursor.Position);
            collectionRoundMenuStrip.Visible = true;
        }
        else
        {
            collectionRoundMenuStrip.Visible = false;
        }
    }
