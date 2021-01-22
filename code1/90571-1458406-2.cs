    private DataTable CreateTable()
    {
        var dtb = new DataTable();
        dtb.Columns.Add(new DataColumn("SerialNo", typeof(int)));
        dtb.Columns.Add("Item");
        for (var i = 1; i < 11; i++)
            dtb.Rows.Add(new object[] { i, i + "" });
         Cache.Add("data", dtb, null, Cache.NoAbsoluteExpiration, 
            TimeSpan.FromMinutes(60), CacheItemPriority.Normal, null);
            
        return dtb;
    }
    protected void AddClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtItem.Text)) return;
        var table = Cache["data"] as DataTable;
        if (table == null) return;
        var i = table.Rows.Count + 1;
        table.Rows.Add(new object[] { i, txtItem.Text });
        BindData(table);
    }
