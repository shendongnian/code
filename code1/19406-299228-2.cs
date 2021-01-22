    //set up the datatable
    DataTable dt = new DataTable("parms");
    dt.Columns.Add("ParmName",typeof(string));
    dt.Columns.Add("ParmValue",typeof(string));
    //bind to a gui object
    myDataGridView.DataSource = dt;
    //do this after each sproc call
    foreach (SqlParameter parm in cmd.Parameters)
    {
        if (parm.Direction == ParameterDirection.Output)
        {
            //do something with parm.Value
            dt.Rows.Add(new object [] { parm.ParameterName, 
                Convert.ToString(parm.Value) } );
        }
    }
