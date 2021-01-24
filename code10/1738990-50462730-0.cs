    public DataTable TempTable
    {
        get; set;
    }
    public void dtTemp()
    {
        TempTable = new DataTable();
        TempTable.Columns.Add("ID_", typeof(string));
        TempTable.Columns.Add("Name_", typeof(string));
        TempTable.Columns.Add("Phone_", typeof(string));
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        int rowTotal = Int32.Parse(txtRow.Text);
        dtTemp();
        DataRow dr = TempTable.NewRow();
        for (int i = 0; i < rowTotal; i++)
        {
            dr = TempTable.NewRow();
            dr["ID_"] = "";
            dr["Name_"] = "";
            dr["Phone_"] = "";
            TempTable.Rows.Add(dr);
        }
        grid1.DataSource = TempTable;
        grid1.DataBind();
    }
