    public ActionResult Index(string id)
    {
        // using DRY principle, just write the same part of the query in a string variable
        // and add another part depending on case value inside switch block below
        string baseQuery = @"Select mt.MaterialRequestId, mt.TDate, 
                             d.DepartmentName, it.ItemName, 
                             mt.QtyRequested, mt.Comment, 
                             mt.RecievedDateTime , u.UnitName from MaterialRequest mt 
                             INNER JOIN Department d ON mt.DepartmentId = d.DepartmentId 
                             INNER JOIN Items it ON mt.ItemId = it.ItemId 
                             INNER JOIN Units u ON it.UnitId = u.UnitId";
        switch (id)
        {
            case "Open":
                baseQuery += " where QtyRecieved = QtyRequested";
                break;
            case "Partial":
                baseQuery += " where QtyRecieved < QtyRequested and Void = 0";
                break;
            case "All":
                break; // not doing anything
            default: goto case "All";
        }
        
        // create a list of object from query results
        var items = db.Query<MaterialDeptItemVw>(baseQuery).ToList();
        // return JSON data to populate target element
        return Json(items, JsonRequestBehavior.AllowGet);
    }
