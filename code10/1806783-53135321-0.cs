    protected void btnArea_Click(object sender, EventArgs e)
    {
        string ar = (sender as Button).Text;
        //ar = "Asia";
        string name = "phd" + ar.ToLower(); // The naming format comes here
        Control[] controls = this.Controls.Find(name, true); //find the control(s) by name
        
        foreach(Control control in controls) // mow loop and make them visible
            control.Visible = true;
        //phdasia.Visible = true;
    }
