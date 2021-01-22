    //*****************************************************************
    // Fix AjaxToolKit ComboBox Text when Enter Key is pressed bug.
    //*****************************************************************
    public void FixAjaxToolKitComboBoxTextWhenEnterKeyIsPressedIssue(AjaxControlToolkit.ComboBox _combobox)
    {
        TextBox textBox = _combobox.FindControl("TextBox") as TextBox;
        if (textBox != null)
        {
            if (_combobox.Items.FindByText(textBox.Text) == null)
            {
                _combobox.Items.Add(textBox.Text);
            }
                _combobox.Text = textBox.Text;
            }
        }
    }
