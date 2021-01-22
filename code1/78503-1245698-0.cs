    DataTable dt = new DataTable();
    //for each of your properties
    dt.Columns.Add("PropertyOne", typeof(string));
        
    foreach(Entity entity in entities)
    {
      DataRow row = dt.NewRow();
      //foreach of your properties
      row["PropertyOne"] = entity.PropertyOne;
    
      dt.Rows.Add(row);
    }
    DataSet ds = new DataSet();
    ds.Tables.Add(dt);
    return ds;
