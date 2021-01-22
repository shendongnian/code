     protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
            {
                if (e.Item.ItemType == ListViewItemType.EmptyItem)
                {
                     Control c = e.Item.FindControl("Literal1");
                    if (c != null)
                    {
                        //this will atleast tell you  if the control exists or not
                    }
                }
            }
