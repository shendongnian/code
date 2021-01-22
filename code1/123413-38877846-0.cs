    public List<String> GetSelected()
    {
        List<String> selected = new List<String>();
        foreach(DataGridViewRow row in datagrid.rows)
        {
            if (row.Cells[wantedCell].Value == DBNull.Value ? false : (bool)row.Cells[wantedCell].Value == true)
            {
                selected.Add(row.Cells[anotherCell]);
            }
        }
    }
