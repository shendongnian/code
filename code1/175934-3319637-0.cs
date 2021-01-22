        private void Page_Load(object sender, System.EventArgs e)
    {
        LoopTextboxes(Page.Controls);
    }
    
    private void LoopTextboxes(ControlCollection controlCollection)
    {
        foreach(Control control in controlCollection)
        {
            if(control is TextBox)
            {
                ((TextBox)control).Text = "I am a textbox";
            }
    
            if(control.Controls != null)
            {
                LoopTextboxes(control.Controls);
            }
        }
    }
