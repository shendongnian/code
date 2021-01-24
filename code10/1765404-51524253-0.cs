    JavaScriptSerializer serializer = new JavaScriptSerializer();
    DataTable dt =await oracleManager.GetSchedule(Departure, Arrival, Date);
    if (dt.Rows.Count > 0)
    {
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        foreach (DataRow dr in dt.Rows)
        {
           row = new Dictionary<string, object>();
           foreach (DataColumn col in dt.Columns)
            {
              row.Add(col.ColumnName, dr[col]);
            }
          rows.Add(row);
       }
       //add this line
       var output = new { Success = true, Response = rows };
       // then serialize the new object
       return await Task.FromResult(serializer.Serialize(output));
    }
