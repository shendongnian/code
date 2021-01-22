    /// <summary>
    /// Resets all the controls in a parent control to their default values.
    /// </summary>
    /// <param name="parent">Parent of controls to reset</param>
    protected void ResetChildControls(Control parent)
    {
        if (parent.Controls.Count == 0)
            return;
        foreach (Control child in parent.Controls)
        {
            if (child is TextBox)
            {
                ((TextBox)child).Text = "";
            }
            else if (child is HiddenField)
            {
                ((HiddenField)child).Value = "";
            }
            else if (child is DropDownList)
            {
                DropDownList dropdown = (DropDownList)child;
                if (dropdown.Items.Count > 0)
                {
                    dropdown.SelectedIndex = 0;
                }
            }
            else if (child is RadioButton)
            {
                ((RadioButton)child).Checked = false;
            }
            else if (child is RadioButtonList)
            {
                RadioButtonList rbl = (RadioButtonList)child;
                rbl.SelectedIndex = rbl.Items.Count > 0 ? 0 : -1;
            }
            else if (child is CheckBox)
            {
                ((CheckBox)child).Checked = false;
            }
            else if (child is CheckBoxList)
            {
                CheckBoxList cbl = (CheckBoxList)child;
                cbl.ClearSelection();
            }
            else if (child is DataGrid)
            {
                ((DataGrid)child).SelectedIndex = -1;
            }
            ResetChildControls(child);
        }
    }
