    protected void CheckedControl(object sender, EventArgs e)
    {
        if (sender is CheckBox)
        {
            var checkbox = (CheckBox)sender;
            
            if(checkbox.Checked)
            {
                // It is checked
            }
            
            //Change the checked status
            checkbox.Checked = true;
        }
    }
