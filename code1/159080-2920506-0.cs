     void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
      {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
             if (((MyDataSourceType)e.Item.DataItem).MyLabelText.Length <= 40) {
                ((Label)e.Item.FindControl("myLabel")).Text= String.Empty;
             }
          }
