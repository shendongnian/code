            bool sortAscending = false;
            private void inventoryList_ColumnClick(object sender, ColumnClickEventArgs e)
            {
    
                if (!sortAscending)
                {
                    sortAscending = true;
                }
                else
                {
                    sortAscending = false;
                }
                this.inventoryList.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
    
            }
