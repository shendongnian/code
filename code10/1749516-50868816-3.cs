    void UserControl_Delete_Click(object sender, EventArgs e)
    {
        Button Delete = (Button)sender;
        UserControl UC = (UserControl)Delete.Parent;
        flowLayoutControl2.Controls.Remove(UC);
        UC.Dispose();
    }
