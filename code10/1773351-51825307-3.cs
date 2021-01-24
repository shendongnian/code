    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        MenuItem item = e.Item.DataItem as MenuItem;
        //check if the item exists and if it has subitems
        if (item != null && item.menuitems != null)
        {
            //determine type and get the properties
            Type type = sender.GetType();
            PropertyInfo[] properties = type.GetProperties();
            Object obj = type.InvokeMember("", BindingFlags.CreateInstance, null, sender, null);
            //copy the properties
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(obj, propertyInfo.GetValue(sender, null), null);
                }
            }
            //cast the created object back to a repeater
            Repeater nestedRepeater = obj as Repeater;
            //fill the child repeater with the sub menu items
            nestedRepeater.DataSource = item.menuitems;
            //attach the itemdatabound event
            nestedRepeater.ItemDataBound += Repeater1_ItemDataBound;
            //bind the data
            nestedRepeater.DataBind();
            //find the placeholder and add the created Repeater
            PlaceHolder ph = e.Item.FindControl("PlaceHolder1") as PlaceHolder;
            ph.Controls.Add(nestedRepeater);
        }
    }
