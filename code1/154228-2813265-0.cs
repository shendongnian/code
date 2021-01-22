    foreach (Control c in groupBox1.Controls)
    {
        CheckBox checkbox = c as CheckBox;
        if (checkbox != null)
        {
            if (checkbox.Checked)
            {
                //do something
            }
        }
    }
