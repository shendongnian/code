    private List<ToolStripMenuItem> DBs;
    private void Form1_Load(object sender, EventArgs e)
    {
        DBs = new List<ToolStripMenuItem>
        {
            test1ToolStripMenuItem,
            test2ToolStripMenuItem,
            test3ToolStripMenuItem,
            test4ToolStripMenuItem
        };
        foreach (var DB in DBs)
        {
            DB.Click += FakeRadioBehaviour;
        }
    }
