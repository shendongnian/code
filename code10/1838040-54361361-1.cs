            foreach (ListViewItem lstview in myListViewName.Items)//cleaning and resetting the original/default colors for all items as not selected.
            {
                lstview.UseItemStyleForSubItems = false;
                lstview.SubItems[1].BackColor = Color.White; //settings for column 2 only
                lstview.SubItems[1].ForeColor = Color.Black; //settings for column 2 only
            }
            var info = myListViewName.HitTest(e.X, e.Y); //getting the row index for the item selected.
            var row = info.Item.Index;
            myListViewName.Items[row].Selected = true; //passing the index to the listview to be selected
            myListViewName.Items[row].SubItems[1].BackColor = Color.DodgerBlue; //changing color of single row/column selected
            myListViewName.Items[row].SubItems[1].ForeColor = Color.White; //changing color of single row/column selected
