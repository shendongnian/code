      protected void BindComponentes()
        {
          DataTable dt = new DataTable();
            for (int i = 0; i < Convert.ToInt32(txtNumComponentes.Text); i++)
            {
                
                DataRow dr = null;
    
                  dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(double)));
            //create new row
            dr = dt.NewRow();
    
            //add the row to DataTable
            dt.Rows.Add(dr);
            }
    
           rptComponentes.DataSource = dt;
            rptComponentes.DataBind();
    }
