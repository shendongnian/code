    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropDownList ddl = (DropDownList)e.Item.FindControl("DropDownList1");
        //the product quantity variable
        int productQuantity = 0;
        //cast the repeater item back to a datarowview
        DataRowView item = e.Item.DataItem as DataRowView;
        //or if a List<objects> is bound, cast it back to it's class
        //MyClass item = e.Item.DataItem as MyClass
        //get the quantity from the repeater source item to fill the ddl
        productQuantity = Convert.ToInt32(item["quantity"]);
        //add the items to the ddl
        for (int i = 0; i < productQuantity; i++)
        {
            ddl.Items.Add(new ListItem() { Text = i.ToString(), Value = i.ToString() });
        }
        //add a listitem to the ddl at position 0
        ddl.Items.Insert(0, new ListItem() { Text = "Select Quantity", Value = "" });
    }
