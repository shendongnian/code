    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string value = ((RadioButtonList)sender).SelectedValue;
        char? c = null;
        if (!string.IsNullOrEmpty(value))
        {
            c = value[0];
        }
        RaiseBubbleEvent(this, new CommandEventArgs("SelectedIndexChanged", c));
    }
