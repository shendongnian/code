    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
            if (RadioButtonList1.Items[0].Selected)
            {
                RadioButtonList1.Items[0].Attributes.Add("style", "background-color: green;");
                RadioButtonList1.Items[1].Attributes.Add("style", "background-color: red;");
            }
            if (RadioButtonList1.Items[1].Selected)
            {
                RadioButtonList1.Items[1].Attributes.Add("style", "background-color: green;");
                RadioButtonList1.Items[0].Attributes.Add("style", "background-color: red;");
            }
    }
