     public ActionResult GetSupplierAvg(string cityname, string 
     actualproduct)
     {
        var gsa = db.Database.SqlQuery<string>("select distinct SupplierAvg from 
                   OPIS_Price_import where City=@cn and ActualProduct=@ap", 
        new SqlParameter("@cn", cityname), new SqlParameter("@ap", actualproduct));
        var SupplierAvgList = new List<SelectListItem>();
        foreach (var thing in gsa)
        {
            SupplierAvgList.Add(new SelectListItem { Text = thing, Selected = false, 
            Value = thing });
        }
        ViewBag.SupplierAvgList = SupplierAvgList;
        return View;
     }
