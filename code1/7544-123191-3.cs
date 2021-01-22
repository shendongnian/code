    if (listBox.DataSource is IDictionary)
    {
         listBox.ValueMember = "Value";
         object value = listBox.SelectedValue;
         listBox.ValueMember = ""; //If you need it to generally be empty.
    }
