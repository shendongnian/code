    private bool ascending;
    private int sortColumn;
    private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        List<SomeObject> list = (List<SomeObject>)someBindingSource.DataSource;
        if (e.ColumnIndex != sortColumn) ascending = false;
        
        int 1 = e.ColumnIndex;
        if (i == DescriptionColumn.Index)
            list.Sort(new Comparison<SomeObject>((x,y) => x.ID.CompareTo(y.ID)));
        sortColumn = e.ColumnIndex;
        ascending = !ascending;
        if (!ascending) list.Reverse():
        someBindingSource.ResetBindings(false);
        // you may also have to call dgv.Invalidate();
    }
