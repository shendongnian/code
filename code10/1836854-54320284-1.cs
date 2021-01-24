    private void Form1_Load(object sender, EventArgs e)
    {
        IsMdiContainer = true;
        var sideBar = new Form();
        sideBar.Text = "SideBar";
        sideBar.TopLevel = false;
        sideBar.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        sideBar.Dock = DockStyle.Right;
        this.Controls.Add(sideBar);
        var f1= new Form();
        f1.Text = "Mdi Child 1";
        f1.MdiParent = this;
        var f2 = new Form();
        f2.Text = "Mdi Child 2";
        f2.MdiParent = this;
        sideBar.Show();
        f1.Show();
        f2.Show();
    }
