    foreach (var control in this.Controls)
    {
        if (control is TextBox)
        {
            ((TextBox)control).Text = "";
        }
        if (control is CheckBox)
        {
            ((CheckBox)control).Checked = false;
        }
    }
