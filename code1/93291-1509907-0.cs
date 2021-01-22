        protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
          if (e.Item.ItemType == ListViewItemType.DataItem)
          {
            Label someLabel = (Label)e.Item.FindControl("MyLabel");
            someLabel.Text = "Hurray!";
          }
        }
