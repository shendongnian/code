    private void BindGridView()
        {
            if (Session[key] == null)
            {
                gridView1.DataSource = GetDataSource();
                gridView1.DataBind();
            }
            else
            {
                gridView1.DataSource = (DataTable)Session[key];
                gridView1.DataBind();
            }
    
        }
    protected DataTable GetDataSource()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = new DataTable();
                dt.Columns.Add("ID", typeof(int)).AutoIncrement = true;
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Age", typeof(int));
                DataColumn[] keys = new DataColumn[2];
                keys[0] = dt.Columns["ID"];
                dt.PrimaryKey = keys;
                dt.Rows.Add("1", "first object", 34);
                dt.Rows.Add("2", "second object", 24);
                dt.Rows.Add("3", "third object", 34);
                dt.Rows.Add("4", "fourth object", 24);
                dt.Rows.Add("5", "fifth object", 34);
           
                Session[key] = dt;
                return dt;
            }
            catch
            {
                return null;
            }
        }
    protected void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMain = Session[key] as DataTable;
                //copy the schema of source table
                DataTable dtClone = dtMain.Clone();
                foreach (GridViewRow gv in gridView1.Rows)
                {
                    CheckBox chk = gv.FindControl("chkSelect") as CheckBox;
                    HiddenField hdValue = gv.FindControl("hdValue") as HiddenField;
                    if (chk.Checked)
                    {
                        //get only the rows you want
                        DataRow[] results = dtMain.Select("ID=" + hdValue.Value + "");
                        //populate new destination table
                        foreach (DataRow dr in results)
                        {
                            dtClone.ImportRow(dr);
                        }
                    }
                    gridView2.DataSource = dtClone;
                    gridView2.DataBind();
                }
            }
            catch
            {
                BindGridView();
            }
    
        }
