    protected void send(object sender, EventArgs e)
    {
        //loop all the items in the datalist
        foreach (DataListItem item in datalist.Items)
        {
            //find the textbox with findcontrol
            TextBox tb = item.FindControl("Values") as TextBox;
            //do something with the textbox content
            string value = tb.Text;
        }
    }
