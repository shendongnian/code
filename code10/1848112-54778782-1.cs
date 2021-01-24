    for(int index = 0; index < this.listBox1.SelectedItems.Count; index++)
    {
        DataRowView dRowView = this.listBox1.SelectedItems[index] as DataRowView;
        dRowView["selected"] = true;
    }
    //and merge with your Available items
    DataTable dtNewItems = new DataTable();
    dtNewItems.Columns.Add(new DataColumn("id", typeof(System.Int32)));
    dtNewItems.Columns.Add(new DataColumn("name", typeof(System.String)));
    dtNewItems.Columns.Add(new DataColumn("selected", typeof(bool)));
    //and merge it
    DataTable dtSelected = dtData.DefaultView.ToTable();
    dtSelected.Merge(dtNewItems);
