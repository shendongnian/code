    RadioButton GetCheckedRadio(Control container)
    {
        foreach (var control in container.Controls)
        {
            RadioButton radio = control as RadioButton;
    
            if (radio != null && radio.Checked)
            {
                return radio;
            }
        }
    
        return null;
    }
