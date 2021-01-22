    public void SortListView(int Index)
        {
            DataTable TempTable = new DataTable();
            //Add column names to datatable from listview
            foreach (ColumnHeader iCol in MyListView.Columns)
            {
                TempTable.Columns.Add(iCol.Text);
            }
            //Create a datarow from each listviewitem and add it to the table
            foreach (ListViewItem Item in MyListView.Items)
            {
                 DataRow iRow = TempTable.NewRow();
                 // the for loop dynamically copies the data one by one instead of doing irow[i] = MyListView.Subitems[1]... so on
                for (int i = 0; i < MyListView.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        iRow[i] = Item.Text;
                    }
                    else
                    {
                        iRow[i] = Item.SubItems[i].Text;
                    }
                }
                TempTable.Rows.Add(iRow);
            }
            string SortType = string.Empty;
            //LastCol is a public int variable on the form, and LastSort is public string variable
            if (LastCol == Index)
            {
                if (LastSort == "ASC" || LastSort == string.Empty || LastSort == null)
                {
                    SortType = "DESC";
                    LastSort = "DESC";
                }
                else
                {
                    SortType = "ASC";
                    LastSort = "ASC";
                }
            }
            else
            {
                SortType = "DESC";
                LastSort = "DESC";
            }
            LastCol = Index;
            MyListView.Items.Clear();
            //Sort it based on the column text clicked and the sort type (asc or desc)
            TempTable.DefaultView.Sort = MyListView.Columns[Index].Text + " " + SortType;
            TempTable = TempTable.DefaultView.ToTable();
            //Create a listview item from the data in each row
            foreach (DataRow iRow in TempTable.Rows)
            {
                ListViewItem Item = new ListViewItem();
                List<string> SubItems = new List<string>();
                for (int i = 0; i < TempTable.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        Item.Text = iRow[i].ToString();
                    }
                    else
                    {
                        SubItems.Add(iRow[i].ToString());
                    }
                }
                Item.SubItems.AddRange(SubItems.ToArray());
                MyListView.Items.Add(Item);
            }
        }
