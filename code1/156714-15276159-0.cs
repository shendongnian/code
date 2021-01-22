        private DataTable getSampleDataSource1()
        {
            DataTable dtblResult = new DataTable();
            dtblResult.Columns.Add("Name");
            dtblResult.Columns.Add("Count");
            dtblResult.Rows.Add("Name1", "1");
            dtblResult.Rows.Add("Name2", "3");
            dtblResult.Rows.Add("Name3", "7");
            dtblResult.Rows.Add("Name4", "9");
            return dtblResult;
        }
        private DataTable getSampleDataSource2()
        {
            DataTable dtblResult = new DataTable();
            dtblResult.Columns.Add("Name");
            dtblResult.Columns.Add("Count");
            DataRow drow;
            drow = dtblResult.NewRow();
            dtblResult.Rows.Add(drow);
            drow.ItemArray = new object[] { "Name1", "1" };
            drow = dtblResult.NewRow();
            dtblResult.Rows.Add(drow);
            drow.ItemArray = new object[] { "Name2", "3" };
            drow = dtblResult.NewRow();
            dtblResult.Rows.Add(drow);
            drow.ItemArray = new object[] { "Name3", "7" };
            drow = dtblResult.NewRow();
            dtblResult.Rows.Add(drow);
            drow.ItemArray = new object[] { "Name4", "9" };
            return dtblResult;
        }
        private void setDataSource(ASPxGridView theGridView)
        {
            theGridView.KeyFieldName = "Name";
            theGridView.DataSource = getSampleDataSource1();
            theGridView.DataBind();
        }
