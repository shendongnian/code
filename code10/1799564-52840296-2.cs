    protected void Approve_Click(object sender, EventArgs e)
    {
        //cast the sender back to the checkbox
        CheckBox cb = sender as CheckBox;
        if (cb.Checked)
        {
            //get the parent of the parent (itemtemplate > listiew)
            ListView lv = cb.Parent.Parent as ListView;
            //get the dataitem from the namingcontainer
            ListViewDataItem item = cb.NamingContainer as ListViewDataItem;
            //get the correct datakey with the index of the dataitem
            int ID = Convert.ToInt32(lv.DataKeys[item.DataItemIndex].Values[0]);
            //update database here with the ID
        }
    }
