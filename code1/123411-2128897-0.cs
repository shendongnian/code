    public List<String> GetSelected()
    {
        List<String> selected = new List<String>();
        foreach(DataGridViewRow row in datagrid.Rows)
        {
            object value = row.Cells[wantedCell].Value;
            if (value != null && (Boolean)value)
            {
                selected.Add(row.Cells[anotherCell]);
            }
        }
    }
