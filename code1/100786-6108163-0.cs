    DataTable dt = new DataTable();
    dt.Columns.Add("HeaderText");
    dt.Columns.Add("ContentText");
    
    dt.Rows.Add(new object[] { "Heading 1", "Content 1" });
    dt.Rows.Add(new object[] { "Heading 2", "Content 2" });
    
    databoundaccordion.DataSource = new System.Data.DataTableReader(dt);
    databoundaccordion.DataBind();
