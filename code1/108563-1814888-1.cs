    protected void Page_Load(object sender, EventArgs e)
        {
            MyCustomMessageBox("Machine Cannot Be Deleted");
        }
    
        private void MyCustomMessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
