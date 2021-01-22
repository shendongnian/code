    public ActionResult Index()
    {
        ViewData["Message"] = "Welcome to ASP.NET MVC!";
    
        DataTable dt = new DataTable("MyTable");
        dt.Columns.Add(new DataColumn("Col1", typeof(string)));
        dt.Columns.Add(new DataColumn("Col2", typeof(string)));
        dt.Columns.Add(new DataColumn("Col3", typeof(string)));
    
        for (int i = 0; i < 3; i++)
        {
            DataRow row = dt.NewRow();
            row["Col1"] = "col 1, row " + i;
            row["Col2"] = "col 2, row " + i;
            row["Col3"] = "col 3, row " + i;
            dt.Rows.Add(row);
        }
    
        return View(dt); //passing the DataTable as my Model
    }
