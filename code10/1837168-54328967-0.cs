	public JsonResult GetValue()
    {
        JsonResult json = new JsonResult();
        DataSet ds = GetMyData(); 
       /*LoadDoctordetailsNew is method where i get data from database and convert
          to dataset.It returns a dataset*/
        json.Data = GetJson(ds.Tables[0]);
        json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        return json;
    }
    public static List<Dictionary<string, object>> GetJson(DataTable dt)
    {
        List<Dictionary<string, object>> rows =
           new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return rows;
    }
