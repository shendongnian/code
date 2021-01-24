    public List<string> AlllValuesFromColumn
    {
        get
        {
            int indexOfColumn = listView2.Columns.IndexOf(this.columnHeader1);
            return listView2.Items.OfType<ListViewItem>().Select(x => x.SubItems[indexOfColumn].Text).ToList();
        }
    }
