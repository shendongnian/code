    public ActionResult GetDatatable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Name");
        dt.Rows.Add("1", "abc");
        dt.Rows.Add("1", "abc");
    
        string json = JsonConvert.SerializeObject(dt);
    
        //Call the Web API Controller action method with above string parameter via WebRequest or HttpClient
    }
