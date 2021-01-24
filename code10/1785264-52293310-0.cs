    private void TB_FirstName_TextChanged(object sender, EventArgs e)
    {
        var dt = DGV_SearchResult.DataSource as DataTable;
        if (!string.IsNullOrWhiteSpace(TB_FirstName.Text))
            dt.DefaultView.RowFilter = string.Format("NAM LIKE '%{0}%'", TB_FirstName.Text);
        else
            dt.DefaultView.RowFilter = string.Empty;
    }
