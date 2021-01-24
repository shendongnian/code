    private void RoleBackForm()
    {
        // put here all the containers the contain the controls, panel,groupbox the form itself etc...
        Control[] Containers = { panel1, groupBox1, this };
        // iterate trough all containers
        foreach (Control container in Containers)
        {
            // check control type, cast it and set to default
            foreach (Control childControl in container.Controls)
            {
                if (childControl is ComboBox)
                {
                    ((ComboBox)childControl).SelectedIndex = -1;
                }
                else if (childControl is TextBox)
                {
                    ((TextBox)childControl).Text = string.Empty;
                }
                else if (childControl is RadioButton)
                {
                    ((RadioButton)childControl).Checked = false;
                }
                else if (childControl is CheckBox)
                {
                    ((CheckBox)childControl).Checked = false;
                }
            }
        }
    }
