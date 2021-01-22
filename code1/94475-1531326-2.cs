    private Control SelectedControl;
    private void label_Click(object sender, EventArgs e)
    {
        Control ctrl = sender as Control;
        if(ctrl != null)
            SelectedControl = ctrl;
    }
    private void setfont()
    {
        SelectedControl.Font = selectedfont;
    }
