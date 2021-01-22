    DataSet ds = GetData();
    foreach( DataTable dt in ds.Tables )
    {
       foreach( DataRow row in dt.Rows )
       {
          if ( row["columnName"] != DBNull.Value )
          {
             row["columnName"] = "some data";
          }
       }
    }
    DataBind();
