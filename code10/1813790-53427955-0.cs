    private void CheckControl(Control ctl)
    {
        switch (ctl)
        {
            case TextBox _: 
                MessageBox.Show("This is My TextBox");
                break;
            case Label _: 
                MessageBox.Show("This is My Label");
                break;
        }
    }
