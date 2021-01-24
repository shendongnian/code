       public ActionResult DisplayData(LabourTimeModel ltm)
    {
        LabourTimeEntities db = new LabourTimeEntities();
        string query = "Select ProcessItemName, sum(DATEDIFF(MINUTE, LaborTimeOut,LaborTimeIn)) AS 'TimeSpent' FROM LaborTime group by ProcessItemName";
        string query1 = "ONE MORE QUERY"
        var data = db.Database.SqlQuery<LabourTimeModel>(query).ToList();
        var data1 = db.Database.SqlQuery<LabourTimeModel>(query1).ToList();
        return View(new{Query1=data, Query2= data1});
    }
