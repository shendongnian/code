    private void btn_Click(object sender, EventArgs e)
    {
        bool userControlIsAlreadyInPanel = false;
        //assuming you are cheking if usercontrol_1 is already there on panel
        // you don't want to create new usercontrol, but just bring existing control to the front
        foreach(UserControl control in panel_screen.Controls)
        {
            if (control.GetType() == typeof(usercontrol_1))
            {
                userControlIsAlreadyInPanel = true;
                control.BringToFront();
            }
        }
        if(!userControlIsAlreadyInPanel)
        {
            usercontrol_1 instane = new usercontrol_1();
            panel_screen.Controls.Add(instane);
            instane.Dock = DockStyle.Fill;
            instane.BringToFront();
        }
    }
