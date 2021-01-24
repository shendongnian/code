    private void button1_Click(object sender, EventArgs e)
    {
        
        Form2 f2 = new Form2();
        TabPage tabpage = new TabPage();
        tabpage.Text = f2.Text;
        Program.from.tabControl1.TabPages.Add(tabpage);
        f2.TopLevel = false;
        f2.Parent = tabpage;
        f2.Dock = DockStyle.Fill;
        Program.from.tabControl1.SelectedTab = tabpage;
        f2.Show();
    }
