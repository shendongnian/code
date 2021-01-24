    private void f_Load(object sender, EventArgs e)
    {
        LoadData();
    }
    void LoadData()
    {
        dgv.ColumnDisplayIndexChanged -= dgv_ColumnDisplayIndexChanged;
        dgv.DataSource = null;
        var dt = new DataTable();
        dt.Columns.Add("A");
        dt.Columns.Add("B");
        dt.Columns.Add("C");
        dgv.DataSource = dt;
        dgv.ColumnDisplayIndexChanged += dgv_ColumnDisplayIndexChanged;
    }
