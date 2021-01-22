            protected void gvApplications_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //when a user clicks the "Add New" button, 
            //this code puts focus on the Insert button so when the enter key is clicked, the action occurs
            if (e.Item is GridEditFormInsertItem && e.Item.OwnerTableView.IsItemInserted)
            {
                GridEditFormInsertItem insertItem = (GridEditFormInsertItem)e.Item;
                ImageButton btnInsert = (ImageButton)insertItem.FindControl("PerformInsertButton");
                btnInsert.Focus();
            }
        }
