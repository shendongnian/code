       public ActionResult DisplayData(LabourTimeModel ltm)
    {
        LabourTimeEntities db = new LabourTimeEntities();
        string query = "Select ProcessItemName, sum(DATEDIFF(MINUTE, LaborTimeOut,LaborTimeIn)) AS 'TimeSpent' FROM LaborTime group by ProcessItemName";
        string query1 = "ONE MORE QUERY"
        var data = db.Database.SqlQuery<LabourTimeModel>(query).ToList();
        var data1 = db.Database.SqlQuery<LabourTimeModel>(query1).ToList();
      
        dynamic viewModel = new ExpandoObject();
        viewModel.Query1= data;
        viewModel.Query2=data1;
        return View(viewModel);
    }
