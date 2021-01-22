    foreach (PropertyInfo property in properties)
    {
        Control ctrl = container.FindControl(property.Name);
       
        if (ctrl != null)
        {
            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).Text = (string)property.GetValue(questions[0], null);
            }
            else if (ctrl is Label)
            {
                ((Label)ctrl).Text = (string)property.GetValue(questions[0], null);
            }
            else if (ctrl is CheckBox)
            {
                (CheckBox)ctrl).Checked = (bool)property.GetValue(questions[0], null);
            }
            // etc.. for each control type
        }
    }
