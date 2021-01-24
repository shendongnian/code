    [HttpGet]
    public JsonResult GetRacks(int id) 
    {
        // other stuff related to create list of racks here
        // assume 'ListOfRacks' has type of 'List<Rack>' which contains entire rack information
        var racks = ListOfRacks.Where(x => x.RackId == id)
                               .Select(x => new { Value = x.RackId, Text = x.RackName + " " + x.Alias });
    
        return Json(racks, JsonRequestBehavior.AllowGet);
    }
