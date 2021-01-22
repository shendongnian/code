      protected void DataList1__ItemDataBound(Object sender, DataListItemEventArgs e)
      {
        if (e.Item.ItemType == ListItemType.EditItem)
        {
            Label lbl = (Label)e.Item.FindControl("lbl");
            lbl.Text = "edit mode";
        }
      }
