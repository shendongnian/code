    private void UserControl1_Load(object sender, EventArgs e)
    {
        ((Form)this.Parent).ResizeEnd += new EventHandler(UserControl1_ResizeEnd);
    }
    void UserControl1_ResizeEnd(object sender, EventArgs e)
    {
        MessageBox.Show("Resize end");
    }
