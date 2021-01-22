    foreach(Control control in this.Controls)
    {
        if (control.Tag == "Required")
        {
            DateTimePicker dtp = control as DateTimePicker;
            if (dtp != null)
            {
                // use dtp properties.
            }
            else if (control.Text == "" || control.Text == null)
            {
                errorProvider.SetError(control, "* Required Field");
                bValid = false;
            }
            else
            {
                errorProvider.SetError(control, "");
            }
        }
    }
