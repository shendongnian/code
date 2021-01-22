    private void butUp_Click(object sender, EventArgs e)
    {
        DataTable dtTemp = gridView.DataSource as DataTable;
        
        object[] arr = dtTemp.Rows[0].ItemArray;
        for (int i = 1; i < dtTemp.Rows.Count; i++)
        {
            dtTemp.Rows[i - 1].ItemArray = dtTemp.Rows[i].ItemArray;
        }
        dtTemp.Rows[dtTemp.Rows.Count - 1].ItemArray = arr;
    }
    private void butDown_Click(object sender, EventArgs e)
    {
        DataTable dtTemp = gridView.DataSource as DataTable;
        object[] arr = dtTemp.Rows[dtTemp.Rows.Count - 1].ItemArray;
        for (int i = dtTemp.Rows.Count - 2; i >= 0; i--)
        {
            dtTemp.Rows[i + 1].ItemArray = dtTemp.Rows[i].ItemArray;
        }
        dtTemp.Rows[0].ItemArray = arr;
    }
