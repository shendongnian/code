    DataTable dt = new DataTable("parms");
    dt.Columns.Add("ParmName",typeof(string));
    dt.Columns.Add("ParmValue",typeof(string));
    foreach (SqlParameter parm in cmd.Parameters)
    {
        if (parm.Direction == ParameterDirection.Output)
        {
            //do something with parm.Value
            dt.Rows.Add(new object [] { parm.ParameterName, 
                Convert.ToString(parm.Value) } );
        }
    }
    myDataGridView.DataSource = dt;
